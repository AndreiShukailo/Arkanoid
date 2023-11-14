using DG.Tweening;

namespace App.Scripts.Infrastructure.Buttons.View
{
        public class ButtonAnimation : ButtonAnimationBase
        {
            private const float Duration = 0.2f;
            private Sequence _animation;

            protected override void OnButtonDown()
            {
                _animation.Kill();
                _animation = DOTween.Sequence();
                _animation.Append(transform.DOScale(0.9f, Duration))
                    .SetUpdate(true);
            }

            protected override void OnButtonUp()
            {
                _animation.Kill();
                _animation = DOTween.Sequence();
                _animation.Append(transform.DOScale(1f, Duration))
                    .SetUpdate(true);
            }

            private void OnDestroy() =>
                _animation.Kill();
        }
}