using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CorretionAngleComponent : Component
    {
        public GameObject CollidedGameObject { get; private set; }
        public Rigidbody2D Rigidbody => _rigidbody;
        public float MinBounceAngle => _minBounceAngle;
        
        [Range(5f, 30f)] [SerializeField] private float _minBounceAngle = 15f;
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void Construct(ComponentContainer componentContainer)
        {
            base.Construct(componentContainer);
            ClearCollision();
        }

        public void Correct(GameObject collision)
        {
            CollidedGameObject = collision;
        }

        public void ClearCollision()
        {
            CollidedGameObject = null;
        }
    }
}