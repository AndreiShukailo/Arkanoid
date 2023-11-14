using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View
{
    [Serializable]
    public class PackViewContainer
    {
        [SerializeField] private List<PackView> _packViews = new();
        
        private Dictionary<string, PackView> _keyPack = new ();

        public void Register()
        {
            foreach (var packView in _packViews)
            {
                _keyPack[packView.Key] = packView;
            }
        }

        public PackView Get(string key)
        {
            return _keyPack[key];
        }
    }
}