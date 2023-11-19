using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CollisionHandlerComponent : Component
    {
        public CollisionContext CollisionContext { get; private set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionContext = new CollisionContext(this, other);
        }

        public void ClearContext()
        {
            CollisionContext = null;
        }
    }

    public class CollisionContext
    {
        public readonly CollisionHandlerComponent CollisionHandlerComponent;
        public readonly Collision2D Collision2D;

        public CollisionContext(CollisionHandlerComponent collisionHandlerComponent, Collision2D collision2D)
        {
            CollisionHandlerComponent = collisionHandlerComponent;
            Collision2D = collision2D;
        }
    }
}