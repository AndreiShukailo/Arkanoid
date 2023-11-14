using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View;
using UnityEngine;

namespace App.Scripts.Scenes.StartScene.Installers
{
    public class PacksCreatorInstaller : MonoInstaller
    {
        [SerializeField] private PackViewContainer _packContainer;
        [SerializeField] private Transform _content;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var packCreator = new PacksCreator(
                serviceContainer.Get<PackController>(),
                new PackFactory(serviceContainer.Get<LocalizationController>(), _content),
                _packContainer,
                serviceContainer.Get<SceneLoaderController>());

            serviceContainer.SetServiceSelf(packCreator);
        }
    }
}