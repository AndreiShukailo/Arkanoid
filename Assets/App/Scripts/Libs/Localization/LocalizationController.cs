using System;

namespace App.Scripts.Libs.Localization
{
    public class LocalizationController
    {
        private readonly ILocalizationParser _localizationParser;
        private readonly LocalizationConfig _localizationConfig;
        
        private LocalizationData _localizationData;
        public Action<ILocalizationProvider> OnUpdateLanguage;

        public LocalizationController(ILocalizationParser localizationParser, LocalizationConfig localizationConfig)
        {
            _localizationParser = localizationParser;
            _localizationConfig = localizationConfig;
            CreateLocalizationData();
        }

        private void CreateLocalizationData()
        {
            _localizationData = _localizationParser.CreateLocalizationData(_localizationConfig.LocalizationFilePath);
        }

        public void UpdateLocalization(string language)
        {
            var localizationProvider = new LocalizationProvider(_localizationData, language);
            OnUpdateLanguage?.Invoke(localizationProvider);
        }
    }
}