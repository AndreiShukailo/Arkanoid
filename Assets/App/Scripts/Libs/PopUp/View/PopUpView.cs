using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Libs.PopUp.View
{
    public abstract class PopUpView : SpawnableItemMono
    {
        public Transform EnergyContainer => _energyContainer;
        public Transform Content => _content;
        
        [SerializeField] protected Transform _energyContainer;
        [SerializeField] protected Transform _content;
        [SerializeField] protected Image _block;
        [SerializeField] protected RectTransform _rectTransform;
        [SerializeField] protected LocalizedText _lable;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private CanvasGroup _backGround;

        private float _showDuration = 0.5f;
        private float _hideDuration = 0.3f;

        private Sequence _animation;
        private Vector2 _startPosition;

        public override void OnCreated(IObjectPool objectPool)
        {
            base.OnCreated(objectPool);
            _rectTransform.anchoredPosition =
                new Vector2(0, GetYPosition());
            _startPosition = _rectTransform.anchoredPosition;
            _block.raycastTarget = true;
            _backGround.alpha = 0;
        }

        public override void OnDespawned()
        {
            base.OnDespawned();
            var buttons = _content.GetComponentsInChildren<ButtonView>();
            foreach (var button in buttons)
                button.Remove();
        }

        public virtual void SetLocalization(LocalizationController localizationController)
        {
            if (_lable.LocalizationController != null) return;
            _lable.Construct(localizationController);
        }

        public async Task ProcessShow()
        {
            var popUpAnimation = PopUpAnimation(0, _showDuration);
            var backGroundAnimation = BackGroundAnimation(1, _showDuration);
            await Task.WhenAll(popUpAnimation, backGroundAnimation);
            SetBlock(false);
        }

        public async Task ProcessHide()
        {
            SetBlock(true);
            var popUpAnimation = PopUpAnimation(_startPosition.y, _hideDuration);
            var backGroundAnimation = BackGroundAnimation(0, _hideDuration);
            await Task.WhenAll(popUpAnimation, backGroundAnimation);
            Remove();
        }

        private Task BackGroundAnimation(float alpha, float duration)
        {
            _animation = DOTween.Sequence();
            _animation.Append(_backGround.DOFade(alpha, duration)).SetUpdate(true);
            return _animation.AsyncWaitForCompletion();
        }

        private Task PopUpAnimation(float yPos, float duration)
        {
            _animation = DOTween.Sequence();
            _animation.Append(_rectTransform.DOAnchorPosY(yPos, duration)).SetUpdate(true);
            return _animation.AsyncWaitForCompletion();
        }

        public void SetBlock(bool isBlock)
        {
            _block.raycastTarget = isBlock;
        }

        private float GetYPosition()
        {
            return _parent.rect.yMin - _rectTransform.sizeDelta.y / 2;
        }
    }
}