namespace App.Scripts.Libs.TiledParser
{
    public class LevelParser : ILevelParser
    {
        private readonly ITiledMapProvider _tiledMapProvider;

        public LevelParser(ITiledMapProvider tiledMapProvider)
        {
            _tiledMapProvider = tiledMapProvider;
        }

        public LevelInfo CreateLevelGrid(string levelPath)
        {
            var tiledMap = _tiledMapProvider.CreateTiledMap(levelPath);
            var tiledLayer = tiledMap.layers[0];
            var levelData = tiledLayer.data;
            var levelGrid = new int[tiledLayer.height][];
            
            
            for (int i = 0; i < levelGrid.Length; i++)
            {
                levelGrid[i] = new int[tiledLayer.width];
                for (int j = 0; j < tiledLayer.width; j++)
                {
                    int index = i * (tiledLayer.width) + j;
                    levelGrid[i][j] = levelData[index];
                }
            }

            return new LevelInfo(levelGrid, tiledLayer.width);
        }
    }
}