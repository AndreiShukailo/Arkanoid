using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSpeed
{
    public class BoostPlatformSpeedSystem : BoostSystem<BoostPlatformSpeedComponent>
    {
        private readonly LevelController _levelController;
        private float _boostFactor = 1;

        public BoostPlatformSpeedSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        protected override void OnUpdateAction()
        {
            _levelController.Platform.Get<MovingComponent>().SetSpeedFactor(_boostFactor);
        }

        protected override void OnActivateAction(BoostPlatformSpeedComponent component)
        {
            _boostFactor = component.BoostFactor;
        }

        protected override void OnDisableBoostAction()
        {
            _boostFactor = 1f;
        }
    }
}