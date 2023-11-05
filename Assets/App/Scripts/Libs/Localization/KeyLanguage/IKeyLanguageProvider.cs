namespace App.Scripts.Libs.Localization.KeyLanguage
{
    public interface IKeyLanguageProvider
    {
        KeyLanguageData GetKeyLanguage(string languageName);
    }
}