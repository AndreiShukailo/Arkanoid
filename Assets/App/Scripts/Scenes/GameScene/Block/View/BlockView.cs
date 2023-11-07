using App.Scripts.Infrastructure.Collider;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.View
{
    public class BlockView : SpawnableItemMono, ICollidedItem
    {
        public string BlockKey => _blockKey;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        [SerializeField] private string _blockKey;
        
        private ICollidedModel _collidedModel;

        public void Construct(Vector2 size, Vector2 positions)
        {
            SetPosition(positions);
            Resize(size);
        }

        public void AddModel(ICollidedModel collidedModel)
        {
            _collidedModel = collidedModel;
        }

        private void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        private void Resize(Vector2 size)
        {
            _spriteRenderer.size = size;
            _boxCollider2D.size = size;
        }

        public void OnCollide()
        {
            _collidedModel.OnCollide();
        }
    }
}