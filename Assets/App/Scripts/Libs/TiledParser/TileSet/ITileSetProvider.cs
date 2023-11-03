using App.Scripts.Libs.TiledParser.Data;

namespace App.Scripts.Libs.TiledParser.TileSet
{
    public interface ITileSetProvider
    {
        public TiledTileSet CreateTiledTileSet(string tiledMapPath);
    }
}