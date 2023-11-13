using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.StartScene.Language.PopUp;
using UnityEngine;

namespace App.Scripts.Scenes.StartScene.Installers
{
    public class LanguagePopInstaller : MonoInstaller
    {
        [SerializeField] private LanguagePopupPoolSetting _poolSetting;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var languagePopupFactory =
                new LanguagePopupFactory(
                    _poolSetting, 
                    serviceContainer.Get<ButtonManager>(),
                    serviceContainer.Get<CommandChangeState>());

            var popupController = serviceContainer.Get<PopUpController>();
            popupController.AddPopup(_poolSetting.SpawnableItemMono.PopUpKey, languagePopupFactory);
        }
    }
}