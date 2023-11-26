using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CollisionHandlerComponent : Component
    {
        public CollisionContext CollisionContext { get; private set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionContext = new CollisionContext(this, other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CollisionContext = new CollisionContext(this, other.gameObject);
        }

        public void ClearContext()
        {
            CollisionContext = null;
        }
    }

    public class CollisionContext
    {
        public readonly CollisionHandlerComponent CollisionHandlerComponent;
        public readonly GameObject CollisionObject;

        public CollisionContext(CollisionHandlerComponent collisionHandlerComponent, GameObject collision2D)
        {
            CollisionHandlerComponent = collisionHandlerComponent;
            CollisionObject = collision2D;
        }
    }
}