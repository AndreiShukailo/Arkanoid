using App.Scripts.Scenes.GameScene.Block.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    public interface IBlockCreator
    {
        public IBlockModel Create(int blockId,Vector2 position, Vector2 size);
    }
}