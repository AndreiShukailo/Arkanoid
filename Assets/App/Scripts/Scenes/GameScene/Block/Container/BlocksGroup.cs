using System;
using System.Collections.Generic;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    public class BlocksGroup : MonoBehaviour
    {
        public string GroupKey;
        public List<BlockPoolSetting> _blocks;

        public Dictionary<string, IFactory<BlockModel, BlockContext>> CreateGroup(
            Func<BlockPoolSetting, IFactory<BlockModel, BlockContext>> factoryCreator)
        {
            var group = new Dictionary<string, IFactory<BlockModel, BlockContext>>();
            for (var i = 0; i < _blocks.Count; i++)
                group[_blocks[i].SpawnableItemMono.BlockKey] = factoryCreator.Invoke(_blocks[i]);

            return group;
        }
    }
}