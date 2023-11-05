using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.TiledParser.Data;
using App.Scripts.Scenes.GameScene.Level.Level.Config;
using UnityEngine;

namespace App.Scripts.Libs.TiledParser.TileSet
{
    class TileSetProvider : ITileSetProvider
    {
        private readonly TextDataProvider _textDataProvider;

        public TileSetProvider(TextDataProvider textDataProvider)
        {
            _textDataProvider = textDataProvider;
        }

        public TiledTileSet CreateTiledTileSet(TileSetConfig tileSetConfig)
        {
            var tiledMapJson = _textDataProvider.Load(tileSetConfig.TileSetPath);
            return JsonUtility.FromJson<TiledTileSet>(tiledMapJson);
        }
    }
}