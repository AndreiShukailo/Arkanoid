using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.Buttons
{
    public class ButtonManagerInstaller : MonoInstaller
    {
        [SerializeField] private ButtonsViewContainer _buttonsViewContainer;
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var buttonManager = new ButtonManager(_buttonsViewContainer);
            serviceContainer.SetServiceSelf(buttonManager);
        }
    }
}