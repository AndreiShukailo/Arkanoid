using App.Scripts.Infrastructure.Effects;
using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Libs.Components
{
    public class SimpleCollisionAction : ICollisionAction
    {
        private readonly EffectViewFactory _effectViewFactory;
        private const string IronBlockId = "IronBlock";
        private const string BorderId = "Border";

        public SimpleCollisionAction(EffectViewFactory effectViewFactory)
        {
            _effectViewFactory = effectViewFactory;
        }

        public void Collision(CollisionContext collisionContext, ComponentContainer collidedComponent)
        {
            collisionContext.CollisionHandlerComponent.ComponentContainer.Get<CorretionAngleComponent>()?.Correct(collisionContext.Collision);

            if (collidedComponent.ID is BorderId or IronBlockId)
                _effectViewFactory.Create(collisionContext.Collision.contacts[0].point);
            
            collidedComponent.AddToSystem<HealthComponent>();
            collidedComponent.AddToSystem<BombComponent>();
            collidedComponent.AddToSystem<SpawnBoostComponent>();
            collidedComponent.AddToSystem<BoostActivatorComponent>();
        }
    }
}