using System;
using System.Collections.Generic;
using App.Scripts.Scenes.GameScene.Block.Factory;

namespace App.Scripts.Scenes.GameScene.Block
{
    [Serializable]
    public class BlocksContainer
    {
        public List<BlocksGroup> Groups;
        private readonly Dictionary<string, IBlockFactory> _keyFactoryGroup = new();

        public void RegisterGroup(string groupKey, Func<BlockPoolSetting,IBlockFactory> factoryCreator)
        {
            var group = Groups.Find((p) => p.GroupKey == groupKey);
            var dictionary = group.CreateGroup(factoryCreator);
            foreach (var blockFactory in dictionary)
                _keyFactoryGroup.Add(blockFactory.Key, blockFactory.Value);
        }
        
        public IBlockFactory GetFactory(string key)
        {
            return _keyFactoryGroup.TryGetValue(key, out var factory)
                ? factory
                : null;
        }
    }
}