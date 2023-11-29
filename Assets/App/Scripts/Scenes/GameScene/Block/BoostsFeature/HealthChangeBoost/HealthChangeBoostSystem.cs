using App.Scripts.Libs.Components;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Platform.Animations;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.HealthChangeBoost
{
    public class HealthChangeBoostSystem : ComponentSystem<HealthChangeComponent>
    {
        private readonly HealthController _healthController;
        private readonly LevelController _levelController;

        public HealthChangeBoostSystem(HealthController healthController, LevelController levelController)
        {
            _healthController = healthController;
            _levelController = levelController;
        }

        public override void OnUpdate(HealthChangeComponent component)
        {
            base.OnUpdate(component);
            component.ComponentContainer.AddToSystem<DeathComponent>();
            var healthCount = component.HealthChangeCount;
            var color = healthCount < 0 ? Color.red : Color.green;
            if(_levelController.Platform != null)
                _levelController.Platform.Get<ActivateHealthBoostComponent>().PlayAnimation(color).Forget();
            if(_healthController.Health == 1 && component.HealthChangeCount < 0) return;
            _healthController.ChangeHealth(component.HealthChangeCount);
        }
    }
}