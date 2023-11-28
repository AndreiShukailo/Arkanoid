using System.Threading.Tasks;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Systems;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.Ball.Effects;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;

namespace App.Scripts.Scenes.GameScene.Ball.Systems
{
    public class CheckLooseBallSystem : ISystem
    {
        private readonly LevelController _levelController;
        private readonly FieldInfo _fieldInfo;
        private readonly LooseBallEffector _looseBallEffector;

        public CheckLooseBallSystem(LevelController levelController, FieldInfo fieldInfo,
            LooseBallEffector looseBallEffector)
        {
            _levelController = levelController;
            _fieldInfo = fieldInfo;
            _looseBallEffector = looseBallEffector;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            var container = _levelController.BallContainer;
            for (int i = container.Balls.Count - 1; i >= 0; i--)
            {
                if (IsLoose(container, i))
                    CheckBall(container.Balls[i], container).Forget();
            }
        }

        public void Cleanup()
        {
        }

        private async Task CheckBall(ComponentContainer componentContainer, BallContainer ballContainer)
        {
            ballContainer.RemoveBall(componentContainer);
            await LooseBall(componentContainer);

            if (ballContainer.Balls.Count == 0)
                _levelController.Lose();
        }

        private bool IsLoose(BallContainer container, int i)
        {
            return container.Balls[i].transform.position.y <
                   _fieldInfo.CameraBorders.yMin;
        }

        private async Task LooseBall(ComponentContainer componentContainer)
        {
            await _looseBallEffector.PlayEffect(componentContainer.transform.position);
        }
    }
}