using System.Threading.Tasks;
using App.Scripts.Scenes.SceneGame.Features.Animation;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Animations
{
    public class SpawnBlockAnimation : AnimationTweenBase
    {
        private float _duration;
        
        public async Task PlayAnimation(float duration)
        {
            _duration = duration;
            await StartAsyncAnimation();
        }

        public override async Task StartAsyncAnimation()
        {
            _animation = DOTween.Sequence();
            gameObject.transform.localScale = Vector3.zero;
            _animation.Append(gameObject.transform.DOScale(Vector3.one * 1.2f, _duration * 0.8f))
                .Append(gameObject.transform.DOScale(Vector3.one, _duration * 0.2f))
                .SetUpdate(true);
            await _animation.AsyncWaitForCompletion();
        }
    }
}