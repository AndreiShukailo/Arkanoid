using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.Platform.Config;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField] private PlatformConfig _platformConfig;
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var platformCreator = new PlatformCreator(_platformConfig, serviceContainer.Get<InputSystem>());
            serviceContainer.SetService<IPlatformCreator, PlatformCreator>(platformCreator);
        }
    }
}