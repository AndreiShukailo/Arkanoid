using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Platform.Components;

namespace App.Scripts.Libs.Components
{
    public class CollisionSystem : ComponentSystem<CollisionHandlerComponent>
    {
        private readonly ICollisionAction _simpleCollisionAction;
        private readonly ICollisionAction _fallBallCollisionAction;
        private readonly ICollisionAction _bulletCollisionAction;

        public CollisionSystem(ICollisionAction simpleCollisionAction, ICollisionAction fallBallCollisionAction,
            ICollisionAction bulletCollisionAction)
        {
            _simpleCollisionAction = simpleCollisionAction;
            _fallBallCollisionAction = fallBallCollisionAction;
            _bulletCollisionAction = bulletCollisionAction;
        }

        public override void OnUpdate(CollisionHandlerComponent component)
        {
            base.OnUpdate(component);
            if(component.CollisionContexts.Count == 0) return;
            var collisionContext = component.CollisionContexts[0];
            Collision(collisionContext);
            component.ClearContext(collisionContext);
        }

        private void Collision(CollisionContext collisionContext)
        {
            var collision = collisionContext.CollisionObject;

            if (!collision.TryGetComponent<ComponentContainer>(out var componentContainer)) return;
            var collidedComponent = componentContainer.Get<CollidedComponent>();
            if (collidedComponent == null) return;

            if (collisionContext.CollisionHandlerComponent.ComponentContainer.Get<BallComponent>()?.IsFire == true)
            {
                _fallBallCollisionAction.Collision(collisionContext, componentContainer);
                return;
            }

            if (collisionContext.CollisionHandlerComponent.ComponentContainer.Get<BulletComponent>() != null)
            {
                _bulletCollisionAction.Collision(collisionContext, componentContainer);
                return;
            }

            _simpleCollisionAction.Collision(collisionContext, componentContainer);
        }
    }
}