using System;
using System.Collections.Generic;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.Container
{
    [Serializable]
    public class CrackContainer
    {
        [SerializeField] List<CrackPoolSetting> _cracks = new();

        private Dictionary<CrackPoolSetting, CrackFactory> _crackFactories = new();
        

        public CrackFactory GetCrackFactory(float currentHealth)
        {
            if (_cracks.Count == 0) return null;
            
            var poolId = GetPoolSetting(currentHealth);

            return GetCrackFactory(_cracks[poolId]);
        }

        private CrackFactory GetCrackFactory(CrackPoolSetting crackPoolSetting)
        {
            return _crackFactories.TryGetValue(crackPoolSetting, out var factory)
                ? factory
                : AddFactory(crackPoolSetting);
        }
        
        private CrackFactory AddFactory(CrackPoolSetting crackPoolSetting)
        {
            var crackFactory = new CrackFactory(crackPoolSetting);

            _crackFactories[crackPoolSetting] = crackFactory;

            return crackFactory;
        }

        private int GetPoolSetting(float currentHealth)
        {
            var step = 1f / _cracks.Count;
            var point = 1f;
            
            for (var i = 0; i < _cracks.Count; i++)
            {
                point -= step;
                
                if (currentHealth <= point)
                    continue;
                
                return i;
            }

            return _cracks.Count - 1;
        }
    }
}