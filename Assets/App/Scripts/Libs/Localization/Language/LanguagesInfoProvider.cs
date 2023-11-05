using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Localization.Config;

namespace App.Scripts.Libs.Localization.Language
{
    public class LanguagesInfoProvider : ILanguageInfoProvider
    {
        private readonly TextDataProvider _textDataProvider;
        private readonly LocalizationConfig _localizationConfig;

        public LanguagesInfoProvider(TextDataProvider textDataProvider, LocalizationConfig localizationConfig)
        {
            _textDataProvider = textDataProvider;
            _localizationConfig = localizationConfig;
        }

        public LanguagesInfo GetLanguageInfo()
        {
            var languages = _textDataProvider.Load(_localizationConfig.LocalizationFilePath);
            return new LanguagesInfo(languages.Split("\r\n"));
        }
    }
}