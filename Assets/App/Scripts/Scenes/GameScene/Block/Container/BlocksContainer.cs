using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block
{
    [Serializable]
    public class BlocksContainer
    {
        public List<BlocksGroup> Groups;
        private readonly Dictionary<string, IFactory<BlockModel, BlockContext>> _keyFactoryGroup = new();

        public void RegisterGroup<TSetting>(string groupKey,
            Func<TSetting, ICollideStrategy<BlockModel>> strategyCreator) where TSetting : PoolSetting<BlockView>
        {
            var group = Groups.Find((p) => p.GroupKey == groupKey);
            var dictionary = group.CreateGroup(strategyCreator);
            foreach (var blockFactory in dictionary)
                _keyFactoryGroup.Add(blockFactory.Key, blockFactory.Value);
        }

        public IFactory<BlockModel, BlockContext> GetFactory(string key)
        {
            return _keyFactoryGroup.TryGetValue(key, out var factory)
                ? factory
                : null;
        }
    }
}