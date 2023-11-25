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
            Play(true);
        }

        public void Play(bool isPlay)
        {
            if(isPlay)
                _particleSystem.Play();
            else
                _particleSystem.Stop();
        }

        private void OnParticleSystemStopped()
        {
            Remove();
        }
    }
}