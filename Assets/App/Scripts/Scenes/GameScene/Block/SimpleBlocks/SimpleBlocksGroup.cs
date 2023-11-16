using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.GameScene.Block.Container;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks
{
    public class SimpleBlocksGroup : BlocksGroup
    {
        public List<SimpleBlockSettings> _settings = new();

        protected override void BuildGroup<TSetting>(Dictionary<string, IFactory<BlockModel, BlockContext>> group,
            Func<TSetting, ICollideStrategy<BlockModel>> strategyCreator)
        {
            foreach (var setting in _settings)
            {
                group[setting.SpawnableItemMono.BlockKey] = new BlockFactory<TSetting>(setting,
                    new CollideStrategyFactory<TSetting>(strategyCreator), setting as TSetting);
            }
        }
    }
}