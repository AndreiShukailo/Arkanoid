namespace App.Scripts.Libs.TiledParser.Level
{
    public class LevelInfo
    {
        public readonly int[][] ID;
        public readonly int Width;
        public readonly int TotalElements;

        public LevelInfo(int[][] id, int width, int totalElements)
        {
            ID = id;
            Width = width;
            TotalElements = totalElements;
        }
    }
}