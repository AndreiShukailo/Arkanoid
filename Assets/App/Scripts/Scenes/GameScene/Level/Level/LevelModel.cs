using App.Scripts.Scenes.Game.Level.Level.LevelGrid;

namespace App.Scripts.Scenes.Game.Level.Level
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