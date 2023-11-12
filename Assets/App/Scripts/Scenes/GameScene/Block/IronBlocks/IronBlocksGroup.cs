using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.GameScene.Block.Container;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.IronBlocks
{
    public class IronBlocksGroup : BlocksGroup
    {
        [SerializeField] private IronBlockSetting _setting;

        protected override void BuildGroup<TSetting>(Dictionary<string, IFactory<BlockModel, BlockContext>> group, Func<TSetting, ICollideStrategy<BlockModel>> strategyCreator)
        {
            group[_setting.SpawnableItemMono.BlockKey] = new BlockFactory<TSetting>(_setting,
                new CollideStrategyFactory<TSetting>(strategyCreator), _setting as TSetting);
        }
    }
}