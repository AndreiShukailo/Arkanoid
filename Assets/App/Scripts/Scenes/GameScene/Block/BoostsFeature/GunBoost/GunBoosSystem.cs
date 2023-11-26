using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Platform.Components;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.GunBoost
{
    public class GunBoosSystem : BoostSystem<GunBoostComponent>
    {
        private readonly LevelController _levelController;
        private bool _isActive;

        public GunBoosSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        protected override void OnUpdateAction()
        {
            _levelController.Platform.Get<GunComponent>().SetActive(_isActive);
        }

        protected override void OnActivateAction(GunBoostComponent component)
        {
            _isActive = true;
        }

        protected override void OnDisableBoostAction()
        {
            _isActive = false;
        }
    }
}