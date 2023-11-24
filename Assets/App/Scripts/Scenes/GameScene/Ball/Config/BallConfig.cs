using System;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.Container;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Config
{
    [Serializable]
    public class BallConfig
    {
        public ComponentContainerPoolSetting PoolSetting;
        public float BallBottomOffset = 0.65f;
    }
}