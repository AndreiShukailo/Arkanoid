using System;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Config
{
    [Serializable]
    public class BallConfig
    {
        public float Speed = 3f;
        public Vector2 StartPosition = new Vector2(0, 1f);
        public BallPoolSetting PoolSetting;
    }
}