namespace App.Scripts.Scenes.Game.Level.LevelGrid
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