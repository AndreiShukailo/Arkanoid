using App.Scripts.Libs.Components;

namespace App.Scripts.Scenes.GameScene.Level.Level.LevelGrid
{
    public class Cell
    {
        public CellComponent CellComponent { get; private set; }

        public Cell(CellComponent cellComponent)
        {
            CellComponent = cellComponent;
        }

        public void RemoveCellComponent()
        {
            CellComponent = null;
        }
    }
}