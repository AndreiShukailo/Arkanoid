using System.Threading.Tasks;
using App.Scripts.Infrastructure.Effects;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Effects
{
    public class LooseBallEffector
    {
        private readonly CameraShakeAnimation _cameraShakeAnimation;
        private readonly EffectViewFactory _effectViewFactory;

        public LooseBallEffector(CameraShakeAnimation cameraShakeAnimation, EffectViewFactory effectViewFactory)
        {
            _cameraShakeAnimation = cameraShakeAnimation;
            _effectViewFactory = effectViewFactory;
        }

        public async Task PlayEffect(Vector2 position)
        {
            _effectViewFactory.Create(position);
            await _cameraShakeAnimation.StartAsyncAnimation();
        }
    }
}