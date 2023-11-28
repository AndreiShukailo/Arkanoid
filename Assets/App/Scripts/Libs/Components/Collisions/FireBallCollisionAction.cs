using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Libs.Components
{
    public class FireBallCollisionAction : ICollisionAction
    {
        private const string IronBlockId = "IronBlock";
        private const string BorderId = "Border";
        
        public void Collision(CollisionContext collisionContext, ComponentContainer collidedComponent)
        {
            if (collidedComponent.ID == BorderId)
            {
                collisionContext.CollisionHandlerComponent.ComponentContainer.Get<CorretionAngleComponent>()?.Correct(collisionContext.Collision);
                return;
            }
            
            var healthComponent = collidedComponent.Get<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.CurrentHealth -= 10;
                collidedComponent.AddToSystem<HealthComponent>();
                return;
            }

            if (collidedComponent.ID == IronBlockId)
            {
                collidedComponent.AddToSystem<DeathComponent>();
                return;
            }

            collidedComponent.AddToSystem<BombComponent>();
            collidedComponent.AddToSystem<SpawnBoostComponent>();
            collidedComponent.AddToSystem<BoostActivatorComponent>();
        }
    }
}