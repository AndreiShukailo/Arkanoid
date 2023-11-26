using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Platform.Components;

namespace App.Scripts.Libs.Components
{
    public class BulletCollisionAction : ICollisionAction
    {
        public void Collision(CollisionContext collisionContext, ComponentContainer collidedComponent)
        {
            var bullet = collisionContext.CollisionHandlerComponent.ComponentContainer;
            bullet.AddToSystem<DeathComponent>();
            
            var healthComponent = collidedComponent.Get<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.CurrentHealth -= bullet.Get<BulletComponent>().Damage;
                collidedComponent.AddToSystem<HealthComponent>();
                return;
            }

            collidedComponent.AddToSystem<BombComponent>();
            collidedComponent.AddToSystem<SpawnBoostComponent>();
            collidedComponent.AddToSystem<BoostActivatorComponent>();
        }
    }
}