using App.Scripts.Scenes.Game.Block.View;

namespace App.Scripts.Scenes.Game.Block.Model
{
    public class BlockModel
    {
        private readonly BlockView _blockView;

        public BlockModel(BlockView blockView)
        {
            _blockView = blockView;
        }
    }
}