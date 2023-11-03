using App.Scripts.Infrastructure.SceneManagement.Config;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.SceneManagement.Installer
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private ScenesConfig _scenesConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var sceneLoader = new SceneLoaderController(_scenesConfig);
            serviceContainer.SetServiceSelf(sceneLoader);
        }
    }
}