using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.View
{
    public class BallView : SpawnableItemMono, ICollidedItem
    {
        public Rigidbody2D Rigidbody => _rigidbody2D;
        public float MinBounceAngle { get; private set; }

        [SerializeField] private Rigidbody2D _rigidbody2D;
        private ICollidedModel _collidedModel;


        public void Construct(Vector2 position, float minBounceAngle)
        {
            transform.position = position;
            MinBounceAngle = minBounceAngle;
        }

        public void SetSpeed(float speed)
        {
            _rigidbody2D.velocity = speed * Vector2.down;
        }

        public void AddModel(ICollidedModel collidedModel)
        {
            _collidedModel = collidedModel;
        }

        public void OnCollide()
        {
            _collidedModel.OnCollide();
        }
    }
}