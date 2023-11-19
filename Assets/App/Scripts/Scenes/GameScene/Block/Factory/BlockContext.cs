using App.Scripts.Scenes.GameScene.Level.Level;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class BlockContext
    {
        public readonly Vector2Int GridPosition;
        public readonly Vector2 Position;
        public readonly Vector2 Size;

        public BlockContext(Vector2Int gridPosition, Vector2 position, Vector2 size)
        {
            GridPosition = gridPosition;
            Position = position;
            Size = size;
        }
    }
}