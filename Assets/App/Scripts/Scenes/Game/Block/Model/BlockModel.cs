using App.Scripts.Scenes.Game.Block.View;
using App.Scripts.Scenes.Game.Level.LevelGrid;

namespace App.Scripts.Scenes.Game.Block.Model
{
    public class BlockModel : IBlockModel
    {
        private readonly BlockView _blockView;

        public BlockModel(BlockView blockView)
        {
            _blockView = blockView;
        }
    }
}