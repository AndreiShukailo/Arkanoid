namespace App.Scripts.Scenes.Game.Level.Level.LevelGrid
{
    public class Grid
    {
        public Cell[][] Cells { get; private set; }

        public Grid(Cell[][] cells)
        {
            Cells = cells;
        }
    }
}