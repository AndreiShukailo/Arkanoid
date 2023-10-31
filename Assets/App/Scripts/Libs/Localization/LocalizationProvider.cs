namespace App.Scripts.Libs.Localization
{
    class LocalizationProvider : ILocalizationProvider
    {
        private readonly LocalizationData _localizationData;
        private readonly string _language;

        public LocalizationProvider(LocalizationData localizationData, string language)
        {
            _localizationData = localizationData;
            _language = language;
        }

        public string GetLocalizationText(string key)
        {
            return _localizationData.Localizations[key].GetWord(_language);
        }
    }
}