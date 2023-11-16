using System.Collections.Generic;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks.View
{
    public class CrackView : SpawnableItemMono
    {
        [SerializeField] private List<SpriteRenderer>  _spriteRenderers;

        public void Construct(SpriteRenderer spriteRenderer)
        {
            foreach (var item in _spriteRenderers)
            {
                item.size = spriteRenderer.size;
                transform.position = spriteRenderer.transform.position;
            }
        }
    }
}