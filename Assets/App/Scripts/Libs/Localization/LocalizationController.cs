using System;

namespace App.Scripts.Libs.Localization
{
    public class LocalizationController
    {
        public LocalizationProvider LocalizationProvider { get; private set; }

        private readonly ILocalizationParser _localizationParser;

        private LocalizationData _localizationData;
        public Action<ILocalizationProvider> OnUpdateLanguage;

        public LocalizationController(ILocalizationParser localizationParser, LocalizationConfig localizationConfig)
        {
            _localizationParser = localizationParser;
            CreateLocalizationData(localizationConfig.LocalizationFilePath);
        }

        private void CreateLocalizationData(string path)
        {
            _localizationData = _localizationParser.CreateLocalizationData(path);
        }

        public void UpdateLocalization(string language)
        {
            LocalizationProvider = new LocalizationProvider(_localizationData, language);
            OnUpdateLanguage?.Invoke(LocalizationProvider);
        }
    }
}