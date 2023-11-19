using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class MovingComponent : Component
    {
        public float CurrentSpeed { get; private set; }
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        
        [SerializeField] private float _startSpeed;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public override void OnAdd()
        {
            base.OnAdd();
            CurrentSpeed = _startSpeed;
        }
    }
}