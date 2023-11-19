using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CollisionSystem : ComponentSystem<CollisionHandlerComponent>
    {
        private readonly SystemsContainer _systemsContainer;

        public CollisionSystem(SystemsContainer systemsContainer)
        {
            _systemsContainer = systemsContainer;
        }

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
            _systemsContainer.GetSystem<HealthComponent>().Action(collidedComponent.ComponentContainer.Get<HealthComponent>());
        }
    }
}