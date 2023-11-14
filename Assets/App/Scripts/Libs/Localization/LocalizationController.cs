using System;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;
using App.Scripts.Libs.Localization.KeyLanguage;
using App.Scripts.Libs.Localization.Language;

namespace App.Scripts.Libs.Localization
{
    public class LocalizationController
    {
        public Action OnUpdateLanguage;
        public KeyLanguageData CurrentLanguage { get; private set; }

        public readonly LanguagesInfo LanguagesInfo;
        private readonly LocalizationContainer _localizationContainer;
        private readonly SaveLoadService _saveLoadService;
        private CurrenLanguage _savedCurrentLanguage;

        public LocalizationController(IKeyLanguageProvider keyLanguageProvider,
            ILanguageInfoProvider languageInfoProvider, SaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            LanguagesInfo = languageInfoProvider.GetLanguageInfo();

            _savedCurrentLanguage = GetSavedCurrentLanguage();
            _localizationContainer = new LocalizationContainer(keyLanguageProvider);
            UpdateLocalization(_savedCurrentLanguage.Language);
        }

        public void UpdateLocalization(string languageName)
        {
            CurrentLanguage = _localizationContainer.GetKeyLanguageData(languageName);
            OnUpdateLanguage?.Invoke();
            _savedCurrentLanguage.Language = languageName;
            _saveLoadService.Save(_savedCurrentLanguage);
        }

        private CurrenLanguage GetSavedCurrentLanguage()
        {
            return _saveLoadService.Load<CurrenLanguage>()
                   ?? new CurrenLanguage(LanguagesInfo.DefaultLanguage);
        }
    }
}