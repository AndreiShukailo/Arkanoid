using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public interface IBlockFactory : IFactory<IBlockModel, BlockContext>
    {
    }

    class BlockFactory : IBlockFactory
    {
        private readonly PoolProviderMono<BlockView> _objectPoolProvider;

        public BlockFactory(BlockPoolSetting poolSetting)
        {
            _objectPoolProvider = new PoolProviderMono<BlockView>(poolSetting);
        }

        public virtual IBlockModel Create(BlockContext context)
        {
            var blockView = _objectPoolProvider.ObjectPool.Spawn();
            blockView.Construct(context.Size, context.Position);
            return new BlockModel(blockView);
        }
    }
}