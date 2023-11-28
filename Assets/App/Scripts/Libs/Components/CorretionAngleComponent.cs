using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CorretionAngleComponent : Component
    {
        public Collision2D CollidedGameObject { get; private set; }
        public Rigidbody2D Rigidbody => _rigidbody;
        public float MinBounceAngle => _minBounceAngle;
        
        [Range(5f, 30f)] [SerializeField] private float _minBounceAngle = 15f;
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void Construct(ComponentContainer componentContainer)
        {
            base.Construct(componentContainer);
            ClearCollision();
        }

        public void Correct(Collision2D collision2D)
        {
            CollidedGameObject = collision2D;
        }

        public void ClearCollision()
        {
            CollidedGameObject = null;
        }
    }
}