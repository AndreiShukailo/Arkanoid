using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.HealthChangeBoost
{
    public class HealthChangeComponent : Component
    {
        public int HealthChangeCount => _healthChangeCount;
        [SerializeField] private int _healthChangeCount = 1;
    }
}