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
        
        [SerializeField] private BoxCollider2D _boxCollider2D;
        [SerializeField] private SpriteRenderer _left;
        [SerializeField] private SpriteRenderer _right;
        [SerializeField] private float _defaultSize = 0.8f;

        public void Resize(float resizeFactor)
        {
            _boxCollider2D.size = new Vector2(_defaultSize * 2 * resizeFactor, _boxCollider2D.size.y);
            _right.size = new Vector2(_defaultSize * resizeFactor, _right.size.y);
            _left.size = new Vector2(_defaultSize * resizeFactor, _left.size.y);
            
            OnResize?.Invoke();
        }
    }
}