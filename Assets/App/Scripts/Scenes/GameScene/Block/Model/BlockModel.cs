using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block.Model
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