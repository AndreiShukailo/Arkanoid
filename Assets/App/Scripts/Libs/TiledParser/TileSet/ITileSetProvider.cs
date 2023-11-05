using App.Scripts.Libs.TiledParser.Data;
using App.Scripts.Scenes.GameScene.Level.Level.Config;

namespace App.Scripts.Libs.TiledParser.TileSet
{
    public interface ITileSetProvider
    {
        public TiledTileSet CreateTiledTileSet(TileSetConfig tileSetConfig);
    }
}