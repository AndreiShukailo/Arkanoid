using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CollisionHandlerComponent : Component
    {
        public List<CollisionContext> CollisionContexts { get; } = new ();

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionContexts.Add(new CollisionContext(this, other));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CollisionContexts.Add(new CollisionContext(this, other));
        }

        public void ClearContext(CollisionContext collisionContext)
        {
            CollisionContexts.Remove(collisionContext);
        }
    }

    public class CollisionContext
    {
        public readonly CollisionHandlerComponent CollisionHandlerComponent;
        public readonly GameObject CollisionObject;
        public readonly Collision2D Collision;

        public CollisionContext(CollisionHandlerComponent collisionHandlerComponent, Collision2D other)
        {
            CollisionHandlerComponent = collisionHandlerComponent;
            CollisionObject = other.gameObject;
            Collision = other;
        }
        
        public CollisionContext(CollisionHandlerComponent collisionHandlerComponent, Collider2D other)
        {
            CollisionHandlerComponent = collisionHandlerComponent;
            CollisionObject = other.gameObject;
            Collision = null;
        }
    }
}