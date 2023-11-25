using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSpeed
{
    public class BoostPlatformSpeedComponent : BoostComponent
    {
        public float BoostFactor => _boostFactor;
        [Range(0, 10f)] [SerializeField] private float _boostFactor = 2f;
    }
}