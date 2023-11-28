using System;
using DG.Tweening;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Platform.Components
{
    public class PlatformSizeComponent : Component
    {
        public SpriteRenderer Left => _left;
        public SpriteRenderer Right => _right;

        [SerializeField] private PolygonCollider2D _poligonCollider2D;
        [SerializeField] private SpriteRenderer _left;
        [SerializeField] private SpriteRenderer _right;
        [SerializeField] private float _defaultSize = 0.8f;
        [SerializeField] private float _resizeDuration = 0.5f;
        private float _lastFactor;


        private readonly Vector2[] _default =
        {
            new(0.26f, 0.57f),
            new(-0.26f, 0.57f),
            new(-0.73f, 0.55f),
            new(-0.8f, 0.4f),
            new(-0.8f, 0.21f),
            new(0.8f, 0.21f),
            new(0.8f, 0.4f),
            new(0.73f, 0.55f)
        };

        public void Resize(float resizeFactor)
        {
            if (Math.Abs(resizeFactor - _lastFactor) == 0) return;
            _lastFactor = resizeFactor;
            UpdateColliderSize(resizeFactor);
            
            DOTween.ToAxis(() => _left.size,
                x => _left.size = x,
                _defaultSize * resizeFactor, _resizeDuration);
            DOTween.ToAxis(() => _right.size,
                x => _right.size = x,
                _defaultSize * resizeFactor, _resizeDuration);
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