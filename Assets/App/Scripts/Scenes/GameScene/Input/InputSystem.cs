using System;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Input
{
    public class InputSystem : ISystem
    {
        public Action<Vector2> OnTouch;
        public bool IsTouching { get; private set; }

        private readonly Camera _camera;
        private readonly FieldInfo _fieldInfo;
        private bool _isEnabled;

        public InputSystem(Camera camera, FieldInfo fieldInfo)
        {
            _camera = camera;
            _fieldInfo = fieldInfo;
        }

        public void Init()
        {
            _isEnabled = true;
        }

        public void Update(float dt)
        {
            if (!_isEnabled) return;

            IsTouching = false;
            
            if (UnityEngine.Input.GetMouseButton(0))
            {
                var mousePosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

                if (mousePosition.y >= _fieldInfo.FieldRect.yMax)
                    return;

                IsTouching = true;
                OnTouch?.Invoke(mousePosition);
            }
        }

        public void Cleanup()
        {
            _isEnabled = false;
            IsTouching = false;
        }
    }
}