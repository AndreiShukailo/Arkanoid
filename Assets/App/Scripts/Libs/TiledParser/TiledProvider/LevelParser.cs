namespace App.Scripts.Libs.TiledParser
{
    public class LevelParser : ILevelParser
    {
        private readonly ITiledMapProvider _tiledMapProvider;

        public LevelParser(ITiledMapProvider tiledMapProvider)
        {
            _tiledMapProvider = tiledMapProvider;
        }

        public int[][] CreateLevelGrid(string levelPath)
        {
            var tiledMap = _tiledMapProvider.CreateTiledMap(levelPath);
            var tiledLayer = tiledMap.layers[0];
            var levelData = tiledLayer.data;
            var levelGrid = new int[tiledLayer.height][];
            
            
            for (int i = 0; i < levelGrid.Length; i++)
            {
                levelGrid[i] = new int[tiledLayer.width - 1];
                for (int j = 0; j < tiledLayer.width - 1; j++)
                {
                    int index = i * (tiledLayer.width - 1) + j;
                    levelGrid[i][j] = levelData[index];
                }
            }

            return levelGrid;
        }
    }

    public interface ILevelParser
    {
        public int[][] CreateLevelGrid(string levelPath);
    }
}