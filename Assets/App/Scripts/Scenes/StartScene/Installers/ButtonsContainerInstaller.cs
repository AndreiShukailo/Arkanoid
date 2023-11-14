using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.StartScene.Buttons;
using UnityEngine;

namespace App.Scripts.Scenes.StartScene.Installers
{
    public class ButtonsContainerInstaller : MonoInstaller
    {
        [SerializeField] private ButtonsContainer _buttonsContainer;
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            _buttonsContainer.Register(serviceContainer.Get<LocalizationController>());
            serviceContainer.SetServiceSelf(_buttonsContainer);
        }
    }
}