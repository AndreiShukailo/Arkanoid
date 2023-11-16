using App.Scripts.Scenes.GameScene.Level.Level;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.Factory
{
    public class BlockContext
    {
        public readonly LevelModel LevelModel;
        public readonly Vector2 Position;
        public readonly Vector2 Size;

        public BlockContext(LevelModel levelModel, Vector2 position, Vector2 size)
        {
            LevelModel = levelModel;
            Position = position;
            Size = size;
        }
    }
}