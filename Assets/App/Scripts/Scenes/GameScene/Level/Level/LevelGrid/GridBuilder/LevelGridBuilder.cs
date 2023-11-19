using App.Scripts.Libs.Components;
using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Scenes.GameScene.Block;
using App.Scripts.Scenes.GameScene.Level.LevelField.BlockSize;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder
{
    class LevelGridBuilder : ILevelGridBuilder
    {
        private const string IronBlockKey = "IronBlock";
        private readonly IBlockSizeInfoProvider _blockSizeInfoProvider;
        private readonly IBlockCreator _blockCreator;
        private readonly FieldInfo _fieldInfo;

        public LevelGridBuilder(IBlockSizeInfoProvider blockSizeInfoProvider, IBlockCreator blockCreator,
            FieldInfo fieldInfo)
        {
            _blockSizeInfoProvider = blockSizeInfoProvider;
            _blockCreator = blockCreator;
            _fieldInfo = fieldInfo;
        }

        public Grid BuildGrid(LevelInfo levelInfo)
        {
            var blockSizeInfo = _blockSizeInfoProvider.CreateBlockSizeInfo(levelInfo.Width);
            var spacing = blockSizeInfo.Spacing;

            var blocksId = levelInfo.ID;
            var cells = new Cell[blocksId.Length][];
            var blockSize = new Vector2(blockSizeInfo.Width, blockSizeInfo.Height);

            var lastPositionVertical = Vector2.zero;
            var blockCount = 0;
            for (var i = 0; i < blocksId.Length; i++)
            {
                lastPositionVertical = i == 0
                    ? CreateFirstBlockPosition(blockSize, spacing)
                    : AddVerticalPosition(lastPositionVertical, blockSize, spacing);

                var lastPositionHorizontal = lastPositionVertical;

                cells[i] = new Cell[blocksId[i].Length];
                for (var j = 0; j < blocksId[i].Length; j++)
                {
                    if (j != 0)
                        lastPositionHorizontal = AddHorizontalPosition(lastPositionHorizontal, blockSize, spacing);

                    var cellComponent = CreateCellComponent(blocksId, i, j, lastPositionHorizontal, blockSize);
                    
                    cells[i][j] = new Cell(cellComponent);
                    
                    blockCount = AddBlockCount(cellComponent, blockCount);
                }
            }

            return new Grid(cells, blockCount);
        }

        private CellComponent CreateCellComponent(int[][] blocksId, int i, int j, Vector2 lastPositionHorizontal,
            Vector2 blockSize)
        {
            var cellComponent = _blockCreator.Create(blocksId[i][j], new Vector2Int(i, j),
                lastPositionHorizontal, blockSize);
            return cellComponent;
        }

        private int AddBlockCount(CellComponent cellComponent, int blockCount)
        {
            if (cellComponent == null) return blockCount;
            if (cellComponent.ComponentContainer.ID == IronBlockKey) return blockCount;
            blockCount++;
            return blockCount;
        }

        private Vector2 CreateFirstBlockPosition(Vector2 blockSize, float spacing)
        {
            return new Vector2(_fieldInfo.FieldRect.xMin + blockSize.x / 2 + spacing,
                _fieldInfo.FieldRect.yMax - blockSize.y / 2 - spacing);
        }

        private Vector2 AddHorizontalPosition(Vector2 currentPosition, Vector2 blockSize, float spacing) =>
            new(currentPosition.x + blockSize.x + spacing, currentPosition.y);

        private Vector2 AddVerticalPosition(Vector2 currentPosition, Vector2 blockSize, float spacing) =>
            new(currentPosition.x, currentPosition.y - blockSize.y - spacing);
    }
}