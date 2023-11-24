using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.BlocksGetter
{
    public interface IBlocksGetter
    {
        public IEnumerable<List<CellComponent>> GetBlocks(CellComponent cellComponent, Grid grid);
    }
}