using System.Collections.Generic;
using App.Scripts.Infrastructure.PackManagement.Config;
using App.Scripts.Libs.AssetProvider;

namespace App.Scripts.Infrastructure.PackManagement.Parser
{
    public class PackParser : IPackParser
    {
        private readonly TextDataProvider _textDataProvider;
        private readonly ScriptableObjectDataProvider _scriptableObjectDataProvider;

        public PackParser(TextDataProvider textDataProvider, ScriptableObjectDataProvider scriptableObjectDataProvider)
        {
            _textDataProvider = textDataProvider;
            _scriptableObjectDataProvider = scriptableObjectDataProvider;
        }

        public Dictionary<int, Pack> GetPacks(PackConfig config)
        {
            var packCountText = _textDataProvider.Load(config.PacksPath).Trim();
            var packCount = int.Parse(packCountText);

            var dictionary = new Dictionary<int, Pack>();
            
            for (int i = 1; i <= packCount; i++)
            {
                var pack = _scriptableObjectDataProvider.Load<Pack>(config.PacksPath + "/"+ i);
                dictionary[i] = pack;
            }

            return dictionary;
        }
    }
}