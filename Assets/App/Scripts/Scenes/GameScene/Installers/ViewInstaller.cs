using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Factory;
using App.Scripts.Scenes.GameScene.Level.PackInfoFeature;
using App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp;
using App.Scripts.Scenes.StartScene.Language.PopUp;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private HealthBarView _healthBarView;
        [SerializeField] private HealthItemView _healthItemView;
        [SerializeField] private PackInfoView _packInfoView;
        [SerializeField] private MenuPopupPoolSetting _menuPupUpPoolSetting;
        [SerializeField] private LosePopUpPoolSetting _losePopUpPoolSetting;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            InstallMenuPopup(serviceContainer);
            InstallLosePopup(serviceContainer);
            InstallHealthBarView(serviceContainer);
            InstallPackInfo(serviceContainer);
        }

        private void InstallLosePopup(ServiceContainer serviceContainer)
        {
            var losePopupFactory =
                new LosePopUpFactory(
                    _losePopUpPoolSetting,
                    serviceContainer.Get<ButtonManager>(),
                    serviceContainer.Get<CommandChangeState>());

            var popupController = serviceContainer.Get<PopUpController>();
            popupController.AddPopup(_losePopUpPoolSetting.SpawnableItemMono.PopUpKey, losePopupFactory);
        }

        private void InstallMenuPopup(ServiceContainer serviceContainer)
        {
            var menuPopupFactory =
                new MenuPopupFactory(
                    _menuPupUpPoolSetting,
                    serviceContainer.Get<ButtonManager>(),
                    serviceContainer.Get<CommandChangeState>(),
                    serviceContainer.Get<SceneLoaderController>());

            var popupController = serviceContainer.Get<PopUpController>();
            popupController.AddPopup(_menuPupUpPoolSetting.SpawnableItemMono.PopUpKey, menuPopupFactory);
        }

        private void InstallPackInfo(ServiceContainer serviceContainer)
        {
            var packInfoController = new PackInfoController(serviceContainer.Get<PackController>());
            serviceContainer.SetServiceSelf(packInfoController);
            _packInfoView.Construct(packInfoController);
        }

        private void InstallHealthBarView(ServiceContainer serviceContainer)
        {
            _healthBarView.Construct(
                serviceContainer.Get<HealthController>(),
                new HealthItemFactory(_healthItemView, _healthBarView));
        }
    }
}