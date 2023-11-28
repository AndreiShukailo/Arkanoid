using System.Threading.Tasks;
using App.Scripts.Scenes.SceneGame.Features.Animation;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Animations
{
    public class HitBlockAnimations : AnimationTweenBase
    {
        [SerializeField] private float _duration;

        public override async Task StartAnimation()
        {
            _animation = DOTween.Sequence();
            _animation.Append(transform.DOScale(Vector3.one * 0.9f, _duration * 0.8f))
                .Append(transform.DOScale(Vector3.one, _duration * 0.2f));

            await _animation.AsyncWaitForCompletion();
        }
    }
}