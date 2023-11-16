using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball.Model;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;

namespace App.Scripts.Scenes.GameScene.Ball.Systems
{
    public class CheckLooseBallSystem : ISystem
    {
        private readonly LevelController _levelController;
        private readonly FieldInfo _fieldInfo;

        public CheckLooseBallSystem(LevelController levelController, FieldInfo fieldInfo)
        {
            _levelController = levelController;
            _fieldInfo = fieldInfo;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            var container = _levelController.BallContainer;
            for (int i = container.Balls.Count - 1; i >= 0; i--)
                CheckBall(container.Balls[i], container);
        }

        public void Cleanup()
        {
        }

        private void CheckBall(BallModel ballModel, BallContainer ballContainer)
        {
            if (ballModel.BallView.transform.position.y <
                _fieldInfo.CameraBorders.yMin)
                ballContainer.RemoveBall(ballModel);

            if (ballContainer.Balls.Count == 0)
                _levelController.Loose();
        }
    }
}