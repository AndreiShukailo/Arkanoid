using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostBallSpeed;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems
{
    public class BoostActivatorSystem : ComponentSystem<BoostComponent>
    {
        public override void OnUpdate(BoostComponent component)
        {
            base.OnUpdate(component);
            ActivateBoost(component);
        }

        private void ActivateBoost(BoostComponent component)
        {
            component.ComponentContainer.AddToSystem<BoostBallSpeedComponent>();
        }
    }
}