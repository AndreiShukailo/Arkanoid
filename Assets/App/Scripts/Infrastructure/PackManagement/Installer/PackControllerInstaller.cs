using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.PackManagement.Config;
using App.Scripts.Infrastructure.PackManagement.Parser;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;
using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.PackManagement.Installer
{
    public class PackControllerInstaller : MonoInstaller
    {
        [SerializeField] private PackConfig _packConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var packContainer = new PackContainer(
                new PackParser(
                    serviceContainer.Get<TextDataProvider>(),
                    new ScriptableObjectDataProvider()),
                _packConfig);

            var packController = new PackController(
                serviceContainer.Get<SaveLoadService>(),
                packContainer,
                serviceContainer.Get<EnergyController>());
            serviceContainer.SetServiceSelf(packController);
        }
    }
}