using System.Threading.Tasks;
using App.Scripts.Scenes.SceneGame.Features.Animation;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Animations
{
    public class HitPlatformAnimation : AnimationTweenBase
    {
        [SerializeField] private GameObject _left;
        [SerializeField] private GameObject _right;
        [SerializeField] private float _duration;

        public override async Task StartAsyncAnimation()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_left.transform.DOLocalMoveY(-0.1f, _duration * 0.5f))
                .Join(_right.transform.DOLocalMoveY(-0.1f, _duration * 0.5f))
                .Append(_left.transform.DOLocalMoveY(0, _duration * 0.5f))
                .Join(_right.transform.DOLocalMoveY(0, _duration * 0.5f))
                .SetUpdate(true);

            await _animation.AsyncWaitForCompletion();
        }
    }
}