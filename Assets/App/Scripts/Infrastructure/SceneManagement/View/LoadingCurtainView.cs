using System.Threading.Tasks;
using App.Scripts.Libs.Pool;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Infrastructure.SceneManagement.View
{
    public class LoadingCurtainView : SpawnableItemMono , ILoadingCurtain
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _animationDuration = 0.3f;
        private Sequence _animation;

        public override void OnCreated(IObjectPool objectPool)
        {
            base.OnCreated(objectPool);
            DontDestroyOnLoad(this);
            _canvas.worldCamera = Camera.main;
            _canvasGroup.alpha = 1f;
        }

        public async Task ProcessHide()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_canvasGroup.DOFade(0, _animationDuration));
            await _animation.AsyncWaitForCompletion();
            Remove();
        }

        public async Task ProcessShow()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_canvasGroup.DOFade(1, _animationDuration));
            await _animation.AsyncWaitForCompletion();
        }
    }
}