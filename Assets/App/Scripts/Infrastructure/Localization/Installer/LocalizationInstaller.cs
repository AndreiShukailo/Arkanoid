using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;
using App.Scripts.Infrastructure.States;
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
            var commandChangeState = new CommandChangeState();
            serviceContainer.SetServiceSelf(commandChangeState);
            var textDataProvider = new TextDataProvider();
            serviceContainer.SetServiceSelf(textDataProvider);
            var saveLoadService = new SaveLoadService();
            serviceContainer.SetServiceSelf(saveLoadService);
            serviceContainer.SetServiceSelf(CreateLocalizationController(textDataProvider, saveLoadService));
        }

        private LocalizationController CreateLocalizationController(TextDataProvider textDataProvider, SaveLoadService saveLoadService)
        {
            var keyLanguageDataProvider = new KeyLanguageProvider(textDataProvider,_localizationConfig);
            var languageInfoProvider = new LanguagesInfoProvider(textDataProvider, _localizationConfig);
            return new LocalizationController(keyLanguageDataProvider, languageInfoProvider, saveLoadService);
        }
    }
}