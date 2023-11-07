using System;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.View
{
    public class PlatformView : SpawnableItemMono
    {
        public Rigidbody2D Rigidbody => _rigidbody;
        public Vector2 Position => transform.position;
        
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Construct(Vector2 position)
        {
            transform.position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}