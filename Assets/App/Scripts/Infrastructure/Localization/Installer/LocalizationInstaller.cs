using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.Localization.Installer
{
    public class LocalizationInstaller : MonoInstaller
    {
        [SerializeField] private LocalizationConfig _localizationConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(CreateLocalizationController());
        }

        private LocalizationController CreateLocalizationController()
        {
            var textDataProvider = new TextDataProvider();
            var localizationParser = new LocalizationParser(textDataProvider);
            return new LocalizationController(localizationParser, _localizationConfig);
        }
    }
}