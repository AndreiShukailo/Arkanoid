using App.Scripts.Libs.Components;

namespace App.Scripts.Scenes.GameScene.Level.Level.LevelGrid
{
    public class Grid
    {
        private const string IronBlockID = "IronBlock";
        public int BlockCount { get; private set; }
        public Cell[][] Cells { get; private set; }

        public Grid(Cell[][] cells, int blockCount)
        {
            BlockCount = blockCount;
            Cells = cells;
        }
        
        public void RemoveBlock(CellComponent cellComponent)
        {
            if (cellComponent.ComponentContainer.ID == IronBlockID) return;
            BlockCount--;
        }
    }
}