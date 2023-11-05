using System;
using System.Collections.Generic;
using App.Scripts.Scenes.GameScene.Block.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    public class BlocksGroup : MonoBehaviour
    {
        public string GroupKey;
        public List<BlockPoolSetting> _blocks;

        public Dictionary<string, IBlockFactory> CreateGroup(Func<BlockPoolSetting,IBlockFactory> factoryCreator)
        {
            var group = new Dictionary<string, IBlockFactory>();
            for (var i = 0; i < _blocks.Count; i++)
                group[_blocks[i].SpawnableItemMono.BlockKey] = factoryCreator.Invoke(_blocks[i]);

            return group;
        }
    }
}