using App.Scripts.Libs.AssetProvider;
using UnityEngine;

namespace App.Scripts.Libs.TiledParser
{
    public class TiledMapProvider : ITiledMapProvider
    {
        private readonly TextDataProvider _textDataProvider;

        public TiledMapProvider(TextDataProvider textDataProvider)
        {
            _textDataProvider = textDataProvider;
        }

        public TiledMap CreateTiledMap(string tiledMapPath)
        {
            var tiledMapJson = _textDataProvider.Load(tiledMapPath);
            return JsonUtility.FromJson<TiledMap>(tiledMapJson);
        }
    }
}