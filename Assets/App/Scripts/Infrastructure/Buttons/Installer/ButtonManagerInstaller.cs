using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.Buttons.Installer
{
    public class ButtonManagerInstaller : MonoInstaller
    {
        [SerializeField] private ButtonsViewContainer _buttonsViewContainer;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var buttonManager =
                new ButtonManager(_buttonsViewContainer, serviceContainer.Get<LocalizationController>());
            serviceContainer.SetServiceSelf(buttonManager);
        }
    }
}