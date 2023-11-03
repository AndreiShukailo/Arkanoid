using System;

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
            UpdateLocalization(LanguagesInfo.Languages[1]);
        }
        
        public void UpdateLocalization(string languageName)
        {
            CurrentLanguage = _localizationContainer.GetKeyLanguageData(languageName);
            OnUpdateLanguage?.Invoke();
        }
    }
}