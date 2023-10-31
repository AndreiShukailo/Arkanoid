namespace App.Scripts.Libs.Localization
{
    public interface ILocalizationParser
    {
        public LocalizationData CreateLocalizationData(string localizationFilePath);
    }
}