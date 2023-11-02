using App.Scripts.Libs.AssetProvider;
using UnityEngine;

namespace App.Scripts.Libs.TiledParser.TileSetProvider
{
    class TileSetProvider : ITileSetProvider
    {
        private readonly TextDataProvider _textDataProvider;

        public TileSetProvider(TextDataProvider textDataProvider)
        {
            _textDataProvider = textDataProvider;
        }

        public TiledTileSet CreateTiledTileSet(string tileSetPath)
        {
            var tiledMapJson = _textDataProvider.Load(tileSetPath);
            return JsonUtility.FromJson<TiledTileSet>(tiledMapJson);
        }
    }
}