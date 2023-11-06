using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Infrastructure.Component
{
    public class ItemView : SpawnableItemMono
    {
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        
        [SerializeField] protected SpriteRenderer _spriteRenderer;
    }
}