using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Infrastructure.Effects.View
{
    public class EffectView : SpawnableItemMono
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public override void OnSpawned()
        {
            base.OnSpawned();
            _particleSystem.Play();
        }

        private void OnParticleSystemStopped()
        {
            Remove();
        }
    }
}