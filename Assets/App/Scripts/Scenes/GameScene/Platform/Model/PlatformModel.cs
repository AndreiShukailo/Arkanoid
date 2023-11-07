using System.Threading.Tasks;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Platform.View;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public class PlatformModel
    {
        private PlatformView _platformView;
        private readonly float _speed;
        private readonly InputSystem _inputSystem;
        
        private bool _isMoving;
        private Vector2 _velocity;

        public PlatformModel(PlatformView platformView, float speed, InputSystem inputSystem)
        {
            _platformView = platformView;
            _speed = speed;
            _inputSystem = inputSystem;
            SubscribeOnTouches();
        }

        private void SubscribeOnTouches()
        {
            _inputSystem.OnTouch += OnTouch;
        }

        private void OnTouch(Vector2 touchPosition)
        {
            _velocity = new Vector2(Mathf.Clamp(touchPosition.x - _platformView.Position.x, -1, 1) * _speed, 0f);
            if (_isMoving) return;

            ProcessMovePlatform().Forget();
        }

        private async Task ProcessMovePlatform()
        {
            _isMoving = true;
            
            while (_inputSystem.IsEnabled)
            {
                _platformView.SetVelocity(_velocity);
                await Task.Yield();
            }
            
            _platformView.SetVelocity(Vector2.zero);
            _isMoving = false;
        }
    }
}