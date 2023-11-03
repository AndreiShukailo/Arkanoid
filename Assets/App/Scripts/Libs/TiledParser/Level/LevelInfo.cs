namespace App.Scripts.Libs.TiledParser.Level
{
    public class LevelInfo
    {
        public int[][] ID;
        public int Width;

        public LevelInfo(int[][] id, int width)
        {
            ID = id;
            Width = width;
        }
    }
}