using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CollisionHandlerComponent : Component
    {
        public List<CollisionContext> CollisionContexts { get; private set; } = new ();

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionContexts.Add(new CollisionContext(this, other.gameObject));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CollisionContexts.Add(new CollisionContext(this, other.gameObject));
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

        public CollisionContext(CollisionHandlerComponent collisionHandlerComponent, GameObject collision2D)
        {
            CollisionHandlerComponent = collisionHandlerComponent;
            CollisionObject = collision2D;
        }
    }
}