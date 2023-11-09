using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Cracks;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class BlockFactory : PoolFactory<BlockModel, BlockView, BlockContext>
    {
        private ICrackCreator _crackCreator;

        public BlockFactory(PoolSetting<BlockView> poolSetting, ICrackCreator crackCreator) : base(poolSetting)
        {
            _crackCreator = crackCreator;
        }

        public override BlockModel Create(BlockContext context)
        {
            var blockView = _poolProvider.ObjectPool.Spawn();
            blockView.Construct(context.Size, context.Position);

            var collidedStrategy = new SimpleBlockCollideStrategy(_crackCreator);
            var blockModel = new BlockModel(blockView, collidedStrategy);
            blockModel.SetHealth(4);
            return blockModel;
        }

    }
}