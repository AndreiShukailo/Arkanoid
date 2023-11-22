using System.Collections.Generic;
using System.Linq;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BombsFeature.Info;
using UnityEngine;
using Grid = App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.Grid;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature
{
    public class BombBlocksGetter : IBlocksGetter
    {
        private readonly Vector2Int _nullVector = new(-1, -1);

        public IEnumerable<CellComponent> GetBlocks(CellComponent cellComponent, Grid grid)
        {
            var blocks = new List<CellComponent>();
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

                    if (StepIsValid(grid, newStep, cellComponent, blockDestroyPathIfo))
                    {
                        track[newStep] = point;
                        if (blockDestroyPathIfo.IsOneStep) continue;
                        queue.Enqueue(newStep);
                    }
                }
            }

            foreach (var trackKey in track.Keys)
            {
                if (track[trackKey] == _nullVector) continue;
                var cell = grid.Cells[trackKey.x][trackKey.y].CellComponent;
                if (cell == null) continue;
                blocks.Add(cell);
            }

            return blocks;
        }

        private static bool StepIsValid(Grid grid, Vector2Int stepVector, CellComponent cellComponent,
            IBlockDestroyPathInfo blockDestroyPathInfo)
        {
            return InFieldRange(grid, stepVector, cellComponent) &&
                   ColorBlockStepValid(grid, stepVector, blockDestroyPathInfo);
        }

        private static bool ColorBlockStepValid(Grid grid, Vector2Int stepVector,
            IBlockDestroyPathInfo blockDestroyPathInfo)
        {
            if (!blockDestroyPathInfo.IsColor) return true;
            var cell = grid.Cells[stepVector.x][stepVector.y].CellComponent;
            if (cell == null) return false;
            return cell.ComponentContainer.Get<HealthComponent>() != null;
        }

        private static bool InFieldRange(Grid grid, Vector2Int stepVector, CellComponent cellComponent)
        {
            return stepVector.x >= 0 && stepVector.x < grid.Cells.Length && stepVector.y >= 0 &&
                   stepVector.y < grid.Cells[cellComponent.Position.x].Length;
        }
    }
}