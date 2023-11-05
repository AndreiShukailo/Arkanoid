using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Localization.Config;
using App.Scripts.Libs.Localization.KeyLanguage;
using App.Scripts.Libs.Localization.Language;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.Localization.Installer
{
    public class LocalizationInstaller : MonoInstaller
    {
        [SerializeField] private LocalizationConfig _localizationConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var textDataProvider = new TextDataProvider();
            serviceContainer.SetServiceSelf(textDataProvider);
            serviceContainer.SetServiceSelf(CreateLocalizationController(textDataProvider));
        }

        private LocalizationController CreateLocalizationController(TextDataProvider textDataProvider)
        {
            var keyLanguageDataProvider = new KeyLanguageProvider(textDataProvider,_localizationConfig);
            var languageInfoProvider = new LanguagesInfoProvider(textDataProvider, _localizationConfig);
            return new LocalizationController(keyLanguageDataProvider, languageInfoProvider);
        }
    }
}