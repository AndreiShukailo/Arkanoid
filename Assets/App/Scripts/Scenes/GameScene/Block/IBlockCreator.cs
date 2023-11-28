using System.Threading.Tasks;
using App.Scripts.Libs.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    public interface IBlockCreator
    {
        public Task<CellComponent> Create(int blockId, Vector2Int gridPosition, Vector2 position, Vector2 size, float animationDuration);
    }
}