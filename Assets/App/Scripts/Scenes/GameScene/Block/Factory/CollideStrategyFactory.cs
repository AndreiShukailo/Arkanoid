using System;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class CollideStrategyFactory<TSetting> : IFactory<ICollideStrategy<BlockModel>, TSetting>
    {
        private Func<TSetting, ICollideStrategy<BlockModel>> _collideStrategyCreator;

        public CollideStrategyFactory(Func<TSetting, ICollideStrategy<BlockModel>> collideStrategyCreator)
        {
            _collideStrategyCreator = collideStrategyCreator;
        }

        public ICollideStrategy<BlockModel> Create(TSetting value)
        {
            return _collideStrategyCreator?.Invoke(value);
        }
    }
}