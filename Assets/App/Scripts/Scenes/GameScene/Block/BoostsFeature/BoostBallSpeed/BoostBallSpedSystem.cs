using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostBallSpeed
{
    public class BoostBallSpedSystem : ComponentSystem<BoostBallSpeedComponent>
    {
        private readonly LevelController _levelController;
        private float _timer;
        private float _boostTime;
        private bool _isBoost;

        public BoostBallSpedSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            if (!_isBoost) return;
            if (_timer < _boostTime)
            {
                _timer += dt;
                return;
            }

            Deactivate();
        }

        public override void OnUpdate(BoostBallSpeedComponent component)
        {
            base.OnUpdate(component);
            Activate(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
        }

        private void Activate(BoostBallSpeedComponent component)
        {
            var factor = component.BoostFactor;
            UpdateSpeedFactor(factor);
            _boostTime = component.BoostTime;
            _isBoost = true;
        }

        private void Deactivate()
        {
            UpdateSpeedFactor(1);
            DisableBoost();
        }

        private void UpdateSpeedFactor(float factor)
        {
            foreach (var ball in _levelController.BallContainer.Balls)
            {
                var moving = ball.Get<MovingComponent>();
                moving.SetSpeedFactor(factor);
            }
        }

        private void DisableBoost()
        {
            _isBoost = false;
            UpdateTimer();
        }

        private void UpdateTimer(float boostTime = 0)
        {
            _timer = 0;
            _boostTime = boostTime;
        }
    }
}