using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Platform.Components;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSize
{
    public class BoostPlatformSizeSystem : BoostSystem<BoostPlatformSizeComponent>
    {
        private readonly LevelController _levelController;
        private float _sizeFactor = 1f;

        public BoostPlatformSizeSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        protected override void OnUpdateAction()
        {
            if(_levelController.Platform == null) return;
            _levelController.Platform.Get<PlatformSizeComponent>().Resize(_sizeFactor);
        }

        protected override void OnActivateAction(BoostPlatformSizeComponent component)
        {
            _sizeFactor = component.ResizeFactor;
        }

        protected override void OnDisableBoostAction()
        {
            _sizeFactor = 1f;
        }
    }
}