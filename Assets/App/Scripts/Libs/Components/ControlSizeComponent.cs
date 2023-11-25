using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class ControlSizeComponent : Component
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2D;

        public void Construct(Vector2 size)
        {
            _spriteRenderer.size = size;
            SetTrigger(false);
        }
        
        public void SetTrigger(bool isTrigger)
        {
            _boxCollider2D.isTrigger = isTrigger;
        }
    }
}