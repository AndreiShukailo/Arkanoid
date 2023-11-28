using System.Threading.Tasks;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.TiledParser.Data;
using App.Scripts.Libs.TiledParser.TileSet;
using App.Scripts.Scenes.GameScene.Block.Animations;
using App.Scripts.Scenes.GameScene.Block.Container;
using App.Scripts.Scenes.GameScene.Block.Factory;
using App.Scripts.Scenes.GameScene.Level.Level.Config;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block
{
    class BlockCreator : IBlockCreator
    {
        private readonly BlocksContainer _blocksContainer;
        private readonly TiledTileSet _tileSet;

        public BlockCreator(BlocksContainer blocksContainer, ITileSetProvider tileSetProvider,
            TileSetConfig tileSetConfig)
        {
            _blocksContainer = blocksContainer;
            _tileSet = tileSetProvider.CreateTiledTileSet(tileSetConfig);
        }

        public async Task<CellComponent> Create(int blockId, Vector2Int gridPosition, Vector2 position, Vector2 size, float animationDuration)
        {
            if (blockId == 0)
            {
                await Task.Delay(Mathf.RoundToInt(1000 * animationDuration));
                return null;
            }

            var type = GetBlockType(blockId);
            var factory = _blocksContainer.GetFactory(type);
            var block = factory.Create(new BlockContext(gridPosition, position, size));
            await block.Get<SpawnBlockAnimation>().PlayAnimation(animationDuration);
            return block.Get<CellComponent>();
        }

        private string GetBlockType(int id)
        {
            return _tileSet.tiles[id - 1].type;
        }
    }
}