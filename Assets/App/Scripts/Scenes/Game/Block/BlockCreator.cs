using App.Scripts.Scenes.Game.Block.Model;
using App.Scripts.Scenes.Game.Block.View;
using UnityEngine;

namespace App.Scripts.Scenes.Game.Level.LevelGrid
{
    class BlockCreator : IBlockCreator
    {
        private readonly BlockView _blockView;

        public BlockCreator(BlockView blockView)
        {
            _blockView = blockView;
        }

        public IBlockModel Create(int blockId, Vector2 position, Vector2 size)
        {
            var blockView = Object.Instantiate(_blockView);
            blockView.Construct(size, position);
            return new BlockModel(blockView);
        }
    }
}