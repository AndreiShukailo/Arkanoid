using System;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Platform.Components
{
    public class PlatformSizeComponent : Component
    {
        public event Action OnResize;
        public SpriteRenderer Left => _left;
        public SpriteRenderer Right => _right;
        
        [SerializeField] private PolygonCollider2D _poligonCollider2D;
        [SerializeField] private SpriteRenderer _left;
        [SerializeField] private SpriteRenderer _right;
        [SerializeField] private float _defaultSize = 0.8f;

        private Vector2[] _default =
        {
            new(0.5f, 0.57f),
            new(-0.5f, 0.57f),
            new(-0.73f, 0.55f),
            new(-0.8f, 0.4f),
            new(-0.8f, 0.21f),
            new(0.8f, 0.21f),
            new(0.8f, 0.4f),
            new(0.73f, 0.55f)
        };

        public void Resize(float resizeFactor)
        {
            UpdateColliderSize(resizeFactor);

            _right.size = new Vector2(_defaultSize * resizeFactor, _right.size.y);
            _left.size = new Vector2(_defaultSize * resizeFactor, _left.size.y);
            
            OnResize?.Invoke();
        }

        private void UpdateColliderSize(float resizeFactor)
        {
            var points = _poligonCollider2D.points;
            for (int i = 0; i < points.Length; i++)
                points[i] = new Vector2(_default[i].x * resizeFactor, _default[i].y);

            _poligonCollider2D.points = points;
        }
    }
}