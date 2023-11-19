using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CorretionAngleComponent : Component
    {
        public Collision2D Collision2D { get; private set; }
        public Rigidbody2D Rigidbody => _rigidbody;
        public float MinBounceAngle => _minBounceAngle;
        
        [Range(5f, 30f)] [SerializeField] private float _minBounceAngle = 15f;
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Correct(Collision2D collision)
        {
            Collision2D = collision;
        }

        public void ClearCollision()
        {
            Collision2D = null;
        }
    }
}