using System;
using App.Scripts.Libs.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Input
{
    public class InputSystem : ISystem
    {
        public Action<Vector2> OnTouch;
        public bool IsEnabled { get; private set; }

        private readonly Camera _camera;


        public InputSystem(Camera camera)
        {
            _camera = camera;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                IsEnabled = true;
                OnTouch?.Invoke(_camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition));
            }
            else
            {
                IsEnabled = false;
            }

        }

        public void Cleanup()
        {
        }
    }
}