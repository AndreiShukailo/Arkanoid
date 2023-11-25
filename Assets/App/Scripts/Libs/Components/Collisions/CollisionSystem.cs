using App.Scripts.Scenes.GameScene.Ball.Components;

namespace App.Scripts.Libs.Components
{
    public class CollisionSystem : ComponentSystem<CollisionHandlerComponent>
    {
        private readonly ICollisionAction _simpleCollisionAction;
        private readonly ICollisionAction _fallBallCollisionAction;

        public CollisionSystem(ICollisionAction simpleCollisionAction, ICollisionAction fallBallCollisionAction)
        {
            _simpleCollisionAction = simpleCollisionAction;
            _fallBallCollisionAction = fallBallCollisionAction;
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
            var collision = collisionContext.CollisionObject;
            
            if (!collision.TryGetComponent<ComponentContainer>(out var componentContainer)) return;
            var collidedComponent = componentContainer.Get<CollidedComponent>();
            if(collidedComponent == null ) return;

            if (collisionContext.CollisionHandlerComponent.ComponentContainer.Get<BallComponent>()?.IsFire == true)
            {
                _fallBallCollisionAction.Collision(collisionContext, componentContainer);
                return;
            }
            
            _simpleCollisionAction.Collision(collisionContext, componentContainer);
        }
    }
}