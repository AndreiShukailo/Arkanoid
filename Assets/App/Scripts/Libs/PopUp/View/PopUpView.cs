using System.Threading.Tasks;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.PopUp.View
{
    public class PopUpView : SpawnableItemMono
    {
        public string PopUpKey => _popUpKey;
        [SerializeField] private string _popUpKey;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private LocalizedText _lable;

        private float _showDuration = 0.5f;
        private float _hideDuration = 0.3f;

        private RectTransform _parent;
        private Sequence _animation;
        private Vector2 _startPosition;

        public override void OnCreated(IObjectPool objectPool)
        {
            base.OnCreated(objectPool);
            _parent = _rectTransform.parent as RectTransform;
            _rectTransform.anchoredPosition =
                new Vector2(0, GetYPosition());
            _startPosition = _rectTransform.anchoredPosition;
        }

        public override void OnSpawned()
        {
            base.OnSpawned();
            _parent.gameObject.SetActive(true);
        }

        public void SetLocalization(LocalizationController localizationController)
        {
            if (_lable.LocalizationController != null) return;
            _lable.Construct(localizationController);
        }

        public async Task ProcessShow()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_rectTransform.DOAnchorPosY(0f, _showDuration)).SetUpdate(true);
            await _animation.AsyncWaitForCompletion();
        }

        public async Task ProcessHide()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_rectTransform.DOAnchorPosY(_startPosition.y, _hideDuration)).SetUpdate(true);
            await _animation.AsyncWaitForCompletion();
            _parent.gameObject.SetActive(false);
            Remove();
        }

        private float GetYPosition()
        {
            return _parent.rect.yMin - _rectTransform.sizeDelta.y / 2;
        }
    }
}