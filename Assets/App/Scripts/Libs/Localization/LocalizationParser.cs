using App.Scripts.Libs.AssetProvider;

namespace App.Scripts.Libs.Localization
{
    class LocalizationParser : ILocalizationParser
    {
        private readonly TextDataProvider _textDataProvider;

        public LocalizationParser(TextDataProvider textDataProvider)
        {
            _textDataProvider = textDataProvider;
        }

        public LocalizationData CreateLocalizationData(string localizationFilePath)
        {
            var localizationData = new LocalizationData();
            var textData = _textDataProvider.Load(localizationFilePath);
            var lines = textData.Split("\r\n");
            var header = lines[0].Split(';');
            for (var i = 1; i < lines.Length; i++)
            {
                var row = lines[i].Split(';');
                if(row[0] == string.Empty) continue;
                var keyLanguageData = new KeyLanguageData();
                for (var j = 1; j < row.Length; j++)
                {
                    keyLanguageData.Add(new LanguageData()
                    {
                        LanguageName = header[j],
                        Word = row[j]
                    });
                }

                localizationData.Localizations[row[0]] = keyLanguageData;
            }

            return localizationData;
        }
    }
}