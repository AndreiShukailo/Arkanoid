using System;
using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Factory;

namespace App.Scripts.Scenes.GameScene.Block.Container
{
    [Serializable]
    public class BlocksContainer
    {
        public List<BlocksGroup> Groups;
        private readonly Dictionary<string, IFactory<ComponentContainer, BlockContext>> _keyFactoryGroup = new();

        public void RegisterGroup(string groupKey,
            Func<PoolSetting<ComponentContainer>, IFactory<ComponentContainer, BlockContext>> factoryCreator)
        {
            var group = Groups.Find((p) => p.GroupKey == groupKey);
            var dictionary = group.CreateGroup(factoryCreator);
            foreach (var blockFactory in dictionary)
                _keyFactoryGroup.Add(blockFactory.Key, blockFactory.Value);
        }

        public IFactory<ComponentContainer, BlockContext> GetFactory(string key)
        {
            return _keyFactoryGroup.TryGetValue(key, out var factory)
                ? factory
                : null;
        }
    }
}