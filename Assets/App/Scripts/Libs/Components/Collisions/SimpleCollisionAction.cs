using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Libs.Components
{
    public class SimpleCollisionAction : ICollisionAction
    {
        public void Collision(CollisionContext collisionContext, ComponentContainer collidedComponent)
        {
            collisionContext.CollisionHandlerComponent.ComponentContainer.Get<CorretionAngleComponent>()?.Correct(collisionContext.Collision);
            collidedComponent.AddToSystem<HealthComponent>();
            collidedComponent.AddToSystem<BombComponent>();
            collidedComponent.AddToSystem<SpawnBoostComponent>();
            collidedComponent.AddToSystem<BoostActivatorComponent>();
        }
    }
}