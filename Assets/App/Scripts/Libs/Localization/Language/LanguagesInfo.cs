namespace App.Scripts.Libs.Localization.Language
{
    public class LanguagesInfo
    {
        public string DefaultLanguage;
        public readonly string[] Languages;

        public LanguagesInfo(string[] languages, string defaultLanguage)
        {
            DefaultLanguage = defaultLanguage;
            Languages = languages;
        }
    }
}