using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Libs.Components
{
    public class CollisionSystem : ComponentSystem<CollisionHandlerComponent>
    {
        public override void OnUpdate(CollisionHandlerComponent component)
        {
            base.OnUpdate(component);
            if(component.CollisionContext == null) return;
            
            Collision(component.CollisionContext);
            component.ClearContext();
        }

        private void Collision(CollisionContext collisionContext)
        {
            var collision = collisionContext.Collision2D;
            
            if (!collision.gameObject.TryGetComponent<ComponentContainer>(out var componentContainer)) return;
            var collidedComponent = componentContainer.Get<CollidedComponent>();
            if(collidedComponent == null ) return;

            collisionContext.CollisionHandlerComponent.ComponentContainer.Get<CorretionAngleComponent>()?.Correct(collision);
            componentContainer.AddToSystem<HealthComponent>();
            componentContainer.AddToSystem<BombComponent>();
            componentContainer.AddToSystem<SpawnBoostComponent>();
            componentContainer.AddToSystem<BoostActivatorComponent>();
        }
    }
}