using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Block.View;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    public abstract class BlocksGroup : MonoBehaviour
    {
        public string GroupKey;

        public Dictionary<string, IFactory<BlockModel, BlockContext>> CreateGroup<TSetting>(
            Func<TSetting, ICollideStrategy<BlockModel>> strategyCreator) where TSetting : PoolSetting<BlockView>
        {
            var group = new Dictionary<string, IFactory<BlockModel, BlockContext>>();
            BuildGroup(group, strategyCreator);

            return group;
        }

        protected virtual void BuildGroup<TSetting>(Dictionary<string, IFactory<BlockModel, BlockContext>> group,
            Func<TSetting, ICollideStrategy<BlockModel>> strategyCreator) where TSetting : PoolSetting<BlockView>
        {
        }
    }
}