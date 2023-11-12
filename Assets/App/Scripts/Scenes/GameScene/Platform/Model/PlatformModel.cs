using System;
using System.Threading.Tasks;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Platform.View;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Model
{
    public class PlatformModel
    {
        public bool IsMoving { get; private set; }
        public PlatformView PlatformView { get; }
        public Action Move;
        
        private readonly float _speed;
        private readonly InputSystem _inputSystem;
        private Vector2 _velocity;

        public PlatformModel(PlatformView platformView, float speed, InputSystem inputSystem)
        {
            PlatformView = platformView;
            _speed = speed;
            _inputSystem = inputSystem;
            SubscribeOnTouches();
        }

        public void Remove()
        {
            _inputSystem.OnTouch -= OnTouch;
            PlatformView.Remove();
        }

        private void SubscribeOnTouches()
        {
            _inputSystem.OnTouch += OnTouch;
        }

        private void OnTouch(Vector2 touchPosition)
        {
            _velocity = new Vector2(Mathf.Clamp(touchPosition.x - PlatformView.Position.x, -1, 1) * _speed, 0f);
            if (IsMoving) return;

            ProcessMovePlatform().Forget();
        }

        private async Task ProcessMovePlatform()
        {
            IsMoving = true;
            
            while (_inputSystem.IsTouching)
            {
                PlatformView.SetVelocity(_velocity);
                Move?.Invoke();
                await Task.Yield();
            }
            
            PlatformView.SetVelocity(Vector2.zero);
            IsMoving = false;
        }
    }
}