using App.Scripts.Infrastructure.Effects.View;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Infrastructure.Effects
{
    public class EffectViewFactory : PoolFactory<EffectView, Vector2>
    {
        public EffectViewFactory(PoolSetting<EffectView> poolSetting) : base(poolSetting)
        {
        }

        public override EffectView Create(Vector2 value)
        {
            var effectView =  _poolProvider.ObjectPool.Spawn();
            effectView.transform.position = value;
            return effectView;
        }
    }
}