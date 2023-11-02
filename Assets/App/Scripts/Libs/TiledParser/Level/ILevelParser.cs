namespace App.Scripts.Libs.TiledParser
{
    public interface ILevelParser
    {
        public LevelInfo CreateLevelGrid(string levelPath);
    }
}