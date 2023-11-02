namespace App.Scripts.Libs.TiledParser
{
    public interface ITiledMapProvider
    {
        public TiledMap CreateTiledMap(string tiledMapPath);
    }
}