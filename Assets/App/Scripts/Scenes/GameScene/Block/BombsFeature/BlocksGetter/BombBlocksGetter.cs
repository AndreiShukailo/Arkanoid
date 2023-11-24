using System.Collections.Generic;
using App.Scripts.Libs.Components;
using UnityEngine;
using Grid = App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.Grid;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.BlocksGetter
{
    public class BombBlocksGetter : IBlocksGetter
    {
        private readonly Vector2Int _nullVector = new(-1, -1);

        public IEnumerable<List<CellComponent>> GetBlocks(CellComponent cellComponent, Grid grid)
        {
            var points = new List<Vector2Int>();
            var blockDestroyPathIfo = cellComponent.ComponentContainer.Get<BombComponent>().BlockDestroyPathInfo;
            var firstStep = new Vector2Int(cellComponent.Position.x, cellComponent.Position.y);

            var track = new Dictionary<Vector2Int, Vector2Int>
            {
                [firstStep] = _nullVector
            };
            var queue = new Queue<Vector2Int>();
            queue.Enqueue(firstStep);
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();

                for (var i = 0; i < blockDestroyPathIfo.X.Length; i++)
                {
                    var newStep = point + new Vector2Int(blockDestroyPathIfo.X[i], blockDestroyPathIfo.Y[i]);
                    if (track.ContainsKey(newStep)) continue;

                    if (StepIsValid(grid, newStep, cellComponent))
                    {
                        track[newStep] = point;
                        points.Add(newStep);
                    }
                }

                if (queue.Count != 0) continue;
                var blocks = new List<CellComponent>();
                foreach (var item in points)
                {
                    blocks.Add(GetCellComponent(grid, item));
                    if(blockDestroyPathIfo.IsOneStep) continue;
                    queue.Enqueue(item);
                }
                points.Clear();
                yield return blocks;
            }
        }
        
        
        private CellComponent GetCellComponent(Grid grid, Vector2Int newStep)
        {
            return grid.Cells[newStep.x][newStep.y].CellComponent;
        }

        private bool StepIsValid(Grid grid, Vector2Int stepVector, CellComponent cellComponent)
        {
            return InFieldRange(grid, stepVector, cellComponent);
        }

        private static bool InFieldRange(Grid grid, Vector2Int stepVector, CellComponent cellComponent)
        {
            return stepVector.x >= 0 && stepVector.x < grid.Cells.Length && stepVector.y >= 0 &&
                   stepVector.y < grid.Cells[cellComponent.Position.x].Length;
        }
    }
}