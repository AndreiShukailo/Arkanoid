using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostBallSpeed
{
    public class BoostBallSpeedComponent : BoostComponent
    {
        public float BoostTime => _boostTime;
        public float BoostFactor => _boostFactor;
        [SerializeField] private float _boostTime;
        [Range(0, 10f)] [SerializeField] private float _boostFactor = 2f;
    }
}