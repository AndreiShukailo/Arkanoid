using System;
using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.GameScene.Block.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Container
{
    public class BlocksGroup : MonoBehaviour
    {
        public string GroupKey;
        [SerializeField] private List<ComponentContainerPoolSetting> _poolSettings = new ();

        public Dictionary<string, IFactory<ComponentContainer, BlockContext>> CreateGroup(
            Func<ComponentContainerPoolSetting, IFactory<ComponentContainer, BlockContext>> factoryCreator)
        {
            var group = new Dictionary<string, IFactory<ComponentContainer, BlockContext>>();
            foreach (var poolSetting in _poolSettings)
            {
                group[poolSetting.SpawnableItemMono.ID] = factoryCreator.Invoke(poolSetting);
            }

            return group;
        }
    }
}