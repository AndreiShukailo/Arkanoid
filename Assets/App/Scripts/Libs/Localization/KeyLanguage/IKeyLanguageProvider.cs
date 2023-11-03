namespace App.Scripts.Libs.Localization
{
    public interface IKeyLanguageProvider
    {
        KeyLanguageData GetKeyLanguage(string languageName);
    }
}