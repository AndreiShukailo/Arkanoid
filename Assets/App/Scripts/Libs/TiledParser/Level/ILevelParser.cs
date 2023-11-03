namespace App.Scripts.Libs.TiledParser.Level
{
    public interface ILevelParser
    {
        public LevelInfo CreateLevelGrid(string levelPath);
    }
}