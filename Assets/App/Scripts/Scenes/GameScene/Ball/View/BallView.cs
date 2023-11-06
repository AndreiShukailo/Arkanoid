using App.Scripts.Infrastructure.Component;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.View
{
    public class BallView : ItemView
    {
        public Rigidbody2D Rigidbody => _rigidbody2D;
        public CircleCollider2D Collider2D => _collider;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private CircleCollider2D _collider;
    }
}