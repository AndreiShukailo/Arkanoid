using App.Scripts.Infrastructure.Extensions;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Platform.Components
{
    public class GunComponent : Component
    {
        private const float Offset = 0.2f;
        public Vector2 LeftSpawnPoint {
            get
            {
                var left = _platformSizeComponent.Left.GetRect();
                return  new Vector2(left.xMin + Offset, left.yMax + Offset);
            }
        }

        public Vector2 RightSpawnPoint
        {
            get
            {
                var right = _platformSizeComponent.Right.GetRect();
                return new Vector2(right.xMax - Offset, right.yMax + Offset);
            }
        }
        public float Speed => _speed;
        public bool IsActive { get; private set; }
        [SerializeField] private PlatformSizeComponent _platformSizeComponent;
        [SerializeField] private float _speed = 6f;

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}