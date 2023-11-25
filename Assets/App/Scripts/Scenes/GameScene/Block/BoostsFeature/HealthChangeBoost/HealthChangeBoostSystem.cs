using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.HealthChangeBoost
{
    public class HealthChangeBoostSystem : ComponentSystem<HealthChangeComponent>
    {
        private readonly HealthController _healthController;

        public HealthChangeBoostSystem(HealthController healthController)
        {
            _healthController = healthController;
        }

        public override void OnUpdate(HealthChangeComponent component)
        {
            base.OnUpdate(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
            if(_healthController.Health == 1 && component.HealthChangeCount < 0) return;
            _healthController.ChangeHealth(component.HealthChangeCount);
        }
    }
}