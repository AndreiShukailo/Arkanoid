using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class MovingComponent : Component
    {
        public float CurrentSpeed => _currentSpeed * SpeedFactor;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public float StartSpeed => _startSpeed;
        public float SpeedFactor { get; private set; }

        private float _currentSpeed;
        [SerializeField] private float _startSpeed;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public override void Construct(ComponentContainer componentContainer)
        {
            base.Construct(componentContainer);
            SpeedFactor = 1;
            _currentSpeed = _startSpeed * SpeedFactor;
        }

        public void SetSpeedFactor(float speedFactor)
        {
            SpeedFactor = speedFactor;
        }

        public void SetSpeed(float speed)
        {
            _currentSpeed = speed;
            var velocity = _rigidbody2D.velocity;
            velocity =  velocity.normalized * CurrentSpeed;
            _rigidbody2D.velocity = velocity;
        }
    }
}