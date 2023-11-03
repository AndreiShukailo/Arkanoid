using System;
using System.Collections.Generic;
using App.Scripts.Libs.AssetProvider;

namespace App.Scripts.Libs.Localization
{
    public class KeyLanguageProvider : IKeyLanguageProvider
    {
        private readonly LocalizationConfig _localizationConfig;
        private readonly TextDataProvider _textDataProvider;

        public KeyLanguageProvider(TextDataProvider textDataProvider, LocalizationConfig localizationConfig)
        {
            _localizationConfig = localizationConfig;
            _textDataProvider = textDataProvider;
        }

        public KeyLanguageData GetKeyLanguage(string languageName)
        {
            var keyLanguageText = 
                _textDataProvider.Load(_localizationConfig.LocalizationFilePath + "/" + languageName);

            var lines = keyLanguageText.Split("\r\n");

            var keyWords = new Dictionary<string, string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == String.Empty) continue;

                var keyWord = lines[i].Split(';');
                keyWords[keyWord[0]] = keyWord[1];
            }

            return new KeyLanguageData(keyWords);
        }
    }
}