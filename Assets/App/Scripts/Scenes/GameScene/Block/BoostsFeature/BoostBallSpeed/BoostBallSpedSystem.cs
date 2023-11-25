using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostBallSpeed
{
    public class BoostBallSpedSystem : BoostSystem<BoostBallSpeedComponent>
    {
        private readonly LevelController _levelController;
        private float _currentFactor = 1f;

        public BoostBallSpedSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        protected override void OnUpdateAction()
        {
            _levelController.BallContainer.SetSpeedFactor(_currentFactor);
        }

        protected override void OnActivateAction(BoostBallSpeedComponent component)
        {
            _currentFactor = component.BoostFactor;
        }

        protected override void OnDisableBoostAction()
        {
            _currentFactor = 1f;
        }
    }
}