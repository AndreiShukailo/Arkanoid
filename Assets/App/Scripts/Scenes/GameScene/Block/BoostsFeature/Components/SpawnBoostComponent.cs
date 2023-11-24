using App.Scripts.Libs.Components;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components
{
    public class SpawnBoostComponent : Component
    {
        public ComponentContainer Boost => _boost;
        [SerializeField] private ComponentContainer _boost;
    }
}