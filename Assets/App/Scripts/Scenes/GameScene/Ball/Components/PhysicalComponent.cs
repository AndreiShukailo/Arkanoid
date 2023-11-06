using UnityEngine;
using Component = App.Scripts.Infrastructure.Component.Component;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public class PhysicalComponent : Component, IPhysicalComponent
    {
        public Vector2 Velocity => _rigidbody2D.velocity;

        private readonly Rigidbody2D _rigidbody2D;
        private readonly Collider2D _collider2D;

        public PhysicalComponent(Rigidbody2D rigidbody2D, Collider2D collider2D, Vector2 startVelocity)
        {
            
            _rigidbody2D = rigidbody2D;
            _collider2D = collider2D;
            SetVelocity(startVelocity);
        }

        public void Reflect(Vector2 normal)
        {
            var newVelocity = Vector2.Reflect(Velocity, normal);
            SetVelocity(newVelocity);
        }

        private void SetVelocity(Vector2 newVelocity)
        {
            _rigidbody2D.velocity = newVelocity;
        }
        
        public Rect GetRectCollider()
        {
            var collider2D = _collider2D;
            var bounds = collider2D.bounds;
            return new Rect(bounds.min.x, bounds.min.y,
                bounds.size.x, bounds.size.y);
        }
    }
}