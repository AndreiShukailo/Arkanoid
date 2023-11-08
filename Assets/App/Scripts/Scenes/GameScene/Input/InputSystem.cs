using System;
using App.Scripts.Libs.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Input
{
    public class InputSystem : ISystem
    {
        public Action<Vector2> OnTouch;
        public bool IsTouching { get; private set; }

        private readonly Camera _camera;
        private bool _isEnabled;
        
        public InputSystem(Camera camera)
        {
            _camera = camera;
        }

        public void Init()
        {
            _isEnabled = true;
        }

        public void Update(float dt)
        {
            if(!_isEnabled) return;
            
            if (UnityEngine.Input.GetMouseButton(0))
            {
                IsTouching = true;
                OnTouch?.Invoke(_camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition));
            }
            else
            {
                IsTouching = false;
            }
        }

        public void Cleanup()
        {
            _isEnabled = false;
        }
    }
}