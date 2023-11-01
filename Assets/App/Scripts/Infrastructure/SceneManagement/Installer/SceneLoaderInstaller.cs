using System.Threading.Tasks;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.TaskExtensions;
using UnityEngine;

namespace App.Scripts.Infrastructure.SceneManagement
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private ScenesConfig _scenesConfig;
        [SerializeField] private LoadingCurtainPoolSetting _poolSetting;
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var sceneLoader = new SceneLoader(
                _scenesConfig,
                new LoadingCurtainViewFactory(_poolSetting));
            serviceContainer.SetServiceSelf(sceneLoader);
        }
    }
}