using System.Threading.Tasks;
using App.Scripts.Scenes.SceneGame.Features.Animation;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Animations
{
    public class ActivateHealthBoostComponent : AnimationTweenBase
    {
        [SerializeField] private SpriteRenderer _left;
        [SerializeField] private SpriteRenderer _right;
        [SerializeField] private float _duration = 0.2f;
        private Color _color;

        public async Task PlayAnimation(Color color)
        {
            _color = color;
            await StartAnimation();
        }

        public override async Task StartAnimation()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_left.DOColor(_color, _duration * 0.5f))
                .Join(_right.DOColor(_color, _duration * 0.5f))
                .Append(_left.DOColor(Color.white, _duration * 0.5f))
                .Join(_right.DOColor(Color.white, _duration * 0.5f));
            await _animation.AsyncWaitForCompletion();
        }
    }
}