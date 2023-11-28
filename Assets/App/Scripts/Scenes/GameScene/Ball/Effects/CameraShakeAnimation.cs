using System.Threading.Tasks;
using App.Scripts.Scenes.SceneGame.Features.Animation;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Effects
{
    public class CameraShakeAnimation : AnimationTweenBase
    {
        [SerializeField] private float _duration = 0.1f;
        [SerializeField] private float _strength = 1f;
        [SerializeField] private int _vibrato = 10;
        [SerializeField] private float _randomness = 90f;
        
        public override async Task StartAnimation()
        {
            _animation = DOTween.Sequence();
            _animation.Append(transform.DOShakePosition(_duration, _strength, _vibrato, _randomness));
            await _animation.AsyncWaitForCompletion();
        }
    }
}