using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSize
{
    public class BoostPlatformSizeComponent : BoostComponent
    {
        public float ResizeFactor => _resizeFactor;
        [SerializeField] private float _resizeFactor;
    }
}