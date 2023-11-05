using System.Collections.Generic;

namespace App.Scripts.Libs.Localization.KeyLanguage
{
    public class KeyLanguageData
    {
        private Dictionary<string, string> _keyWords;

        public KeyLanguageData(Dictionary<string, string> keyWords)
        {
            _keyWords = keyWords;
        }

        public string GetWord(string key)
        {
            return _keyWords.TryGetValue(key, out var word) ? word : string.Empty;
        }
    }
}