using System.Threading.Tasks;
using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.Ball.View;
using App.Scripts.Scenes.GameScene.Platform;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Model
{
    public class BallModel : ICollidedModel
    {
        public BallView BallView => _ballView;

        private readonly float _speed;
        private readonly PlatformModel _platformModel;
        private readonly BallView _ballView;

        public BallModel(PlatformModel platformModel, BallView ballView, float speed)
        {
            _platformModel = platformModel;
            _ballView = ballView;
            _speed = speed;
            ballView.AddModel(this);

            _platformModel.Move += OnPlatformMove;
        }

        public void OnCollide()
        {
        }

        private void OnPlatformMove()
        {
            MoveBallWithPlatform().Forget();
            _platformModel.Move -= OnPlatformMove;
        }

        private async Task MoveBallWithPlatform()
        {
            while (_platformModel.IsMoving)
            {
                var ballTransform = _ballView.transform;
                ballTransform.position =
                    new Vector3(_platformModel.PlatformView.Position.x, ballTransform.position.y);
                await Task.Yield();
            }

            _ballView.SetSpeed(_speed);
        }
    }
}