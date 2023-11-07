using System;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Config
{
    [Serializable]
    public class PlatformConfig
    {
        public PlatformPoolSetting PlatformPoolSetting;
        public float StartSpeed = 3f;
        public Vector2 StartPosition;
    }
}