using System;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Config
{
    [Serializable]
    public class PlatformConfig
    {
        [Header("Pool")]
        public PlatformPoolSetting PlatformPoolSetting;
        public float StartSpeed = 3f;
        public float PlatformOffsetBottom = 1.66f;
    }
}