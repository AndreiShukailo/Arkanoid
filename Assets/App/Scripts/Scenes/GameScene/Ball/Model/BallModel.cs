using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Ball.View;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Model
{
    public class BallModel : ICollidedModel
    {
        public BallView BallView => _ballView;

        private readonly float _speed;
        private readonly BallView _ballView;

        public BallModel(BallView ballView, float speed)
        {
            _ballView = ballView;
            _speed = speed;
            ballView.AddModel(this);
        }

        public void Start()
        {
            _ballView.SetSpeed(_speed);
        }

        public void OnCollide()
        {
            
        }
    }
}