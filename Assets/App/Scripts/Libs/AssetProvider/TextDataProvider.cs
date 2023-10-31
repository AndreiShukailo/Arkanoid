using UnityEngine;

namespace App.Scripts.Libs.AssetProvider
{
    public class TextDataProvider : IAssetProvider<string>
    {
        public string Load(string path)
        {
            var textAsset = Resources.Load<TextAsset>(path);
            return textAsset.text;
        }
    }
}