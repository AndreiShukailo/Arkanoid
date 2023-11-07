using System;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Config
{
    [Serializable]
    public class BallConfig
    {
        [Range(0, 90f)]public float MinBounceAngle = 10f;
        public float StartSpeed = 3f;
        public Vector2 StartPosition = new(0, 1f);
        public BallPoolSetting PoolSetting;
    }
}