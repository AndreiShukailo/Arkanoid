using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    class BlockFactory : IBlockFactory
    {
        private readonly PoolProviderMono<BlockView> _objectPoolProvider;

        public BlockFactory(BlockPoolSetting poolSetting)
        {
            _objectPoolProvider = new PoolProviderMono<BlockView>(poolSetting);
        }

        public virtual BlockModel Create(BlockContext context)
        {
            var blockView = _objectPoolProvider.ObjectPool.Spawn();
            blockView.Construct(context.Size, context.Position);

            var collidedStrategy = new BlockCollideStrategy();
            var blockModel = new BlockModel(blockView, collidedStrategy);
            blockView.AddModel(blockModel);

            return blockModel;
        }
    }
}