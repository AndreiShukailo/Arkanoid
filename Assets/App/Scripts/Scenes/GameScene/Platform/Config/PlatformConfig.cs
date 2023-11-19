using System;
using App.Scripts.Scenes.GameScene.Block.Container;

namespace App.Scripts.Scenes.GameScene.Platform.Config
{
    [Serializable]
    public class PlatformConfig
    {
        public ComponentContainerPoolSetting PlatformPoolSetting;
        public float PlatformOffsetBottom = 1.66f;
    }
}