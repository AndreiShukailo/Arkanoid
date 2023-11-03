using App.Scripts.Libs.TiledParser.Data;

namespace App.Scripts.Libs.TiledParser.Tiled
{
    public interface ITiledMapProvider
    {
        public TiledMap CreateTiledMap(string tiledMapPath);
    }
}