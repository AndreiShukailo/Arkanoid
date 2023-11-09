using System;
using App.Scripts.Libs.Localization.KeyLanguage;
using App.Scripts.Libs.Localization.Language;

namespace App.Scripts.Libs.Localization
{
    public class LocalizationController
    {
        public KeyLanguageData CurrentLanguage { get; private set; }
        public readonly LanguagesInfo LanguagesInfo;
        private readonly LocalizationContainer _localizationContainer;

        public Action OnUpdateLanguage;

        public LocalizationController(IKeyLanguageProvider keyLanguageProvider,
            ILanguageInfoProvider languageInfoProvider)
        {
            LanguagesInfo = languageInfoProvider.GetLanguageInfo();
            _localizationContainer = new LocalizationContainer(keyLanguageProvider);
            UpdateLocalization(LanguagesInfo.DefaultLanguage);
        }
        
        public void UpdateLocalization(string languageName)
        {
            CurrentLanguage = _localizationContainer.GetKeyLanguageData(languageName);
            OnUpdateLanguage?.Invoke();
        }
    }
}