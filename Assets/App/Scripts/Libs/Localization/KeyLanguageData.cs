using System.Collections.Generic;

namespace App.Scripts.Libs.Localization
{
    public class KeyLanguageData
    {
        private List<LanguageData> _words = new();

        public void Add(LanguageData languageData)
        {
            _words.Add(languageData);
        }

        public string GetWord(string languageName)
        {
            return _words.Find((p) => p.LanguageName == languageName).Word;
        }
    }
}