using App.Scripts.Libs.TiledParser;
using App.Scripts.Scenes.Game.Level.LevelField;
using App.Scripts.Scenes.Game.Level.LevelField.Config;
using UnityEngine;

namespace App.Scripts.Scenes.Game.Level.LevelGrid
{
    class LevelGridBuilder : ILevelGridBuilder
    {
        private readonly BlockSizeInfo _blockSizeInfo;
        private readonly FieldInfo _fieldInfo;
        private readonly IBlockCreator _blockCreator;

        public LevelGridBuilder(BlockSizeInfo blockSizeInfo, FieldInfo fieldInfo, IBlockCreator blockCreator)
        {
            _blockSizeInfo = blockSizeInfo;
            _fieldInfo = fieldInfo;
            _blockCreator = blockCreator;
        }

        public Grid BuildGrid(LevelInfo levelInfo)
        {
            var blocksId = levelInfo.ID;
            var cells = new Cell[blocksId.Length][];
            var blockSize = new Vector2(_blockSizeInfo.Width, _blockSizeInfo.Height);

            var lastPositionVertical = Vector2.zero;
            for (var i = 0; i < blocksId.Length; i++)
            {
                lastPositionVertical = i == 0 
                    ? CreateFirstBlockPosition(blockSize) :
                    AddVerticalPosition(lastPositionVertical, blockSize);

                var lastPositionHorizontal = lastPositionVertical;

                cells[i] = new Cell[blocksId[i].Length];
                for (var j = 0; j < blocksId[i].Length; j++)
                {
                    if (j != 0)
                        lastPositionHorizontal = AddHorizontalPosition(lastPositionHorizontal, blockSize);

                    cells[i][j] = blocksId[i][j] != 0
                        ? new Cell(new Vector2Int(i, j),
                            _blockCreator.Create(blocksId[i][j], lastPositionHorizontal, blockSize))
                        : new Cell(new Vector2Int(i, j));
                }
            }

            return new Grid(cells);
        }

        private Vector2 CreateFirstBlockPosition(Vector2 blockSize)
        {
            return new Vector2(_fieldInfo.FieldRect.xMin + blockSize.x / 2 + _blockSizeInfo.Spacing,
                _fieldInfo.FieldRect.yMax - blockSize.y / 2 - _blockSizeInfo.Spacing);
        }

        private Vector2 AddHorizontalPosition(Vector2 currentPosition, Vector2 blockSize)
        {
            return new Vector2(currentPosition.x + blockSize.x + _blockSizeInfo.Spacing, currentPosition.y);
        }

        private Vector2 AddVerticalPosition(Vector2 currentPosition, Vector2 blockSize)
        {
            return new Vector2(currentPosition.x, currentPosition.y - blockSize.y - _blockSizeInfo.Spacing);
        }
    }
}