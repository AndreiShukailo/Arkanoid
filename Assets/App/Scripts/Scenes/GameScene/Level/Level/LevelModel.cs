using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public class LevelModel
    {
        public Grid LevelGrid { get; private set; }

        public LevelModel(Grid grid)
        {
            LevelGrid = grid;
        }
    }
}