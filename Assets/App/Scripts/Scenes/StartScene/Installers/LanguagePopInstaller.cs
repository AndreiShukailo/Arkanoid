using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.PopUp.Container;
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
            var popUpContainer = serviceContainer.Get<PopUpContainer>();
            popUpContainer.AddPopUp<LanguagePopUp>(_poolSetting);
            var languagePopUpController = new LanguagePopupController(
                serviceContainer.Get<ButtonManager>(),
                serviceContainer.Get<PopUpController>(),
                serviceContainer.Get<LocalizationController>(),
                serviceContainer.Get<ButtonsContainer>());
            serviceContainer.SetServiceSelf(languagePopUpController);
        }
    }
}