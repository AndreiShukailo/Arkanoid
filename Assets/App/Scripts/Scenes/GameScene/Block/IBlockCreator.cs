using App.Scripts.Scenes.Game.Block.Model;
using UnityEngine;

namespace App.Scripts.Scenes.Game.Block
{
    public interface IBlockCreator
    {
        public IBlockModel Create(int blockId,Vector2 position, Vector2 size);
    }
}