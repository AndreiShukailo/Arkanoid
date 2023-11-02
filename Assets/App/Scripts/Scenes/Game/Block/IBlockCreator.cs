using UnityEngine;

namespace App.Scripts.Scenes.Game.Level.LevelGrid
{
    public interface IBlockCreator
    {
        public IBlockModel Create(int blockId,Vector2 position, Vector2 size);
    }
}