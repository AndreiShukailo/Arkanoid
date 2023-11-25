using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems
{
    public abstract class BoostSystem<TComponent> : ComponentSystem<TComponent> where TComponent : BoostComponent
    {
        private float _timer;
        private float _boostTime;
        private bool _isBoost;
        
        public override void Update(float dt)
        {
            base.Update(dt);
            OnUpdateAction();
            if (!_isBoost) return;
            if (_timer < _boostTime)
            {
                _timer += dt;
                return;
            }

            Deactivate();
        }

        public override void OnUpdate(TComponent component)
        {
            base.OnUpdate(component);
            Activate(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
        }

        protected abstract void OnUpdateAction();

        protected abstract void OnActivateAction(TComponent component);

        protected abstract void OnDisableBoostAction();

        private void Activate(TComponent component)
        {
            OnActivateAction(component);
            _boostTime = component.BoostTime;
            _timer = 0;
            _isBoost = true;
        }

        private void Deactivate()
        {
            DisableBoost();
        }

        private void DisableBoost()
        {
            OnDisableBoostAction();
            _isBoost = false;
            _timer = 0;
            _boostTime = 0;
        }

        public override void ClearSystem()
        {
            Deactivate();
        }
    }
}