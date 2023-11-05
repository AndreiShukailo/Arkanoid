using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class BlockContext
    {
        public Vector2 Position;
        public Vector2 Size;

        public BlockContext(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }
    }
}