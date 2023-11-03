using App.Scripts.Scenes.Game.Block.Model;
using UnityEngine;

namespace App.Scripts.Scenes.Game.Level.Level.LevelGrid
{
    public class Cell
    {
        public Vector2Int Position { get; private set; }
        public IBlockModel Block { get; private set; }

        public Cell(Vector2Int position)
        {
            Position = position;
        }
        
        public Cell(Vector2Int position, IBlockModel block)
        {
            Position = position;
            Block = block;
        }
    }
}