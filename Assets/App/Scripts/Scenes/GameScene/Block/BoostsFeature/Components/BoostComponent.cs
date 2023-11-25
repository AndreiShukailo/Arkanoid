using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components
{
    public abstract class BoostComponent : Component
    {
        public float BoostTime => _boostTime;
        [SerializeField] protected float _boostTime;
    }
}