using System;
using System.Collections.Generic;
using App.Scripts.Scenes.GameScene.Block.Cracks.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Cracks.Container
{
    [Serializable]
    public class CrackContainer
    {
        [SerializeField] List<CrackPoolSetting> _cracks;

        private Dictionary<CrackPoolSetting, CrackFactory> _crackFactories = new();


        public CrackFactory GetCrackFactory(int currentHealth)
        {
            var crackPoolSetting = _cracks[_cracks.Count - currentHealth];

            return GetCrackFactory(crackPoolSetting);
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
    }
}