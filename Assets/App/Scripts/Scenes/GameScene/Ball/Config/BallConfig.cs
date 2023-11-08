using System;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Config
{
    [Serializable]
    public class BallConfig
    {
        [Header("Pool")]
        public BallPoolSetting PoolSetting;
        
        [Range(0, 90f)]public float MinBounceAngle = 10f;
        public float StartSpeed = 3f;
        public float BallBottomOffset = 0.65f;
    }
}