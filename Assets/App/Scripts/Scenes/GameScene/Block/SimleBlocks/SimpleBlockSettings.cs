using System;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.View;

namespace App.Scripts.Scenes.GameScene.Block
{
    [Serializable]
    public class SimpleBlockSettings : PoolSetting<BlockView>
    {
        public int StartHealth;
    }
}