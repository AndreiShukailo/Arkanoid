using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.View;
using App.Scripts.Scenes.GameScene.Level.Level;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class BlockFactory<TSetting> : PoolFactory<BlockModel, BlockView, BlockContext> where TSetting : PoolSetting<BlockView>
    {
        private readonly CollideStrategyFactory<TSetting> _collideStrategyFactory;
        private readonly TSetting _setting;

        public BlockFactory(PoolSetting<BlockView> poolSetting, CollideStrategyFactory<TSetting> collideStrategyFactory, TSetting setting)
            : base(poolSetting)
        {
            _collideStrategyFactory = collideStrategyFactory;
            _setting = setting;
        }

        public override BlockModel Create(BlockContext context)
        {
            var blockView = _poolProvider.ObjectPool.Spawn();
            blockView.Construct(context.Size, context.Position);
            var collideStrategy = _collideStrategyFactory.Create(_setting);
            var blockModel = new BlockModel(blockView, collideStrategy, context.LevelModel);
            return blockModel;
        }
    }
}