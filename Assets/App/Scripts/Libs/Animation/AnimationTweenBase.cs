using System.Threading.Tasks;
using DG.Tweening;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.SceneGame.Features.Animation
{
    public abstract class AnimationTweenBase : Component
    {
        protected Sequence _animation;

        public abstract Task StartAsyncAnimation();

        protected virtual void StopAnimation() =>
            _animation.Kill();

        private void OnDestroy() =>
            StopAnimation();

        public override void OnRemove()
        {
            base.OnRemove();
            StopAnimation();
        }
    }
}