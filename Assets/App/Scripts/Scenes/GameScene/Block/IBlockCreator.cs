using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.Level.Level;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    public interface IBlockCreator
    {
        public BlockModel Create(LevelModel levelModel, int blockId,Vector2 position, Vector2 size);
    }
}