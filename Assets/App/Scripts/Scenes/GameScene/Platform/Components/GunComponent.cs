using App.Scripts.Infrastructure.Extensions;
using App.Scripts.Libs.Components;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Platform.Components
{
    public class GunComponent : Component
    {
        private const float Offset = 0.2f;
        public Vector2 LeftSpawnPoint { get; private set; }
        public Vector2 RightSpawnPoint { get; private set; }
        public float Speed => _speed;
        public bool IsActive { get; private set; }
        [SerializeField] private PlatformSizeComponent _platformSizeComponent;
        [SerializeField] private float _speed = 6f;

        public override void Construct(ComponentContainer componentContainer)
        {
            base.Construct(componentContainer);
            _platformSizeComponent.OnResize += Resize;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            _platformSizeComponent.OnResize -= Resize;
        }

        private void Resize()
        {
            var left = _platformSizeComponent.Left.GetRect();
            LeftSpawnPoint = new Vector2(left.xMin + Offset, left.yMax + Offset);
            
            var right = _platformSizeComponent.Right.GetRect();
            RightSpawnPoint = new Vector2(right.xMax - Offset, right.yMax + Offset);
        }
    }
}