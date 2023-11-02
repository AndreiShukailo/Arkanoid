namespace App.Scripts.Libs.TiledParser.TileSetProvider
{
    public interface ITileSetProvider
    {
        public TiledTileSet CreateTiledTileSet(string tiledMapPath);
    }
}