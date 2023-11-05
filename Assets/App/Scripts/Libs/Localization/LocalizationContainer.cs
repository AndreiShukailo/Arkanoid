using System.Collections.Generic;
using App.Scripts.Libs.Localization.KeyLanguage;

namespace App.Scripts.Libs.Localization
{
    public class LocalizationContainer
    {
        private readonly IKeyLanguageProvider _keyLanguageProvider;
        private readonly Dictionary<string, KeyLanguageData> _localizations = new();

        public LocalizationContainer(IKeyLanguageProvider keyLanguageProvider)
        {
            _keyLanguageProvider = keyLanguageProvider;
        }

        public KeyLanguageData GetKeyLanguageData(string languageName)
        {
            return _localizations.TryGetValue(languageName, out var keyLanguageData)
                ? keyLanguageData
                : AddLanguage(languageName, _keyLanguageProvider.GetKeyLanguage(languageName));
        }

        private KeyLanguageData AddLanguage(string language, KeyLanguageData keyLanguageData)
        {
            _localizations.Add(language, keyLanguageData);

            return keyLanguageData;
        }
    }
}