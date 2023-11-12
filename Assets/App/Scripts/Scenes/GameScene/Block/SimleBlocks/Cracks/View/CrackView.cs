using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.View
{
    public class CrackView : SpawnableItemMono
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Construct(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer.size = spriteRenderer.size;
            transform.position = spriteRenderer.transform.position;
        }
    }
}