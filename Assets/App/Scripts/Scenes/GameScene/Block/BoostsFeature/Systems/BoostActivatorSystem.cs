using App.Scripts.Infrastructure.Effects;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostAddBall;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostBallSpeed;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostFireBall;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSize;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSpeed;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.GunBoost;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.HealthChangeBoost;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems
{
    public class BoostActivatorSystem : ComponentSystem<BoostActivatorComponent>
    {
        private readonly EffectViewFactory _effectViewFactory;

        public BoostActivatorSystem(EffectViewFactory effectViewFactory)
        {
            _effectViewFactory = effectViewFactory;
        }

        public override void OnUpdate(BoostActivatorComponent component)
        {
            base.OnUpdate(component);
            ActivateBoost(component);
        }

        private void ActivateBoost(BoostActivatorComponent component)
        {
            _effectViewFactory.Create(component.transform.position);
            component.ComponentContainer.AddToSystem<BoostBallSpeedComponent>();
            component.ComponentContainer.AddToSystem<BoostPlatformSizeComponent>();
            component.ComponentContainer.AddToSystem<BoostFireBallComponent>();
            component.ComponentContainer.AddToSystem<BoostAddBallComponent>();
            component.ComponentContainer.AddToSystem<BoostPlatformSpeedComponent>();
            component.ComponentContainer.AddToSystem<HealthChangeComponent>();
            component.ComponentContainer.AddToSystem<GunBoostComponent>();
        }
    }
}