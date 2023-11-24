using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BombsFeature.Info;
using UnityEngine;
using Grid = App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.Grid;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.BlocksGetter
{
    public class ColorBombBlocksGetter : IBlocksGetter
    {
        private readonly Vector2Int _nullVector = new(-1, -1);

        public IEnumerable<List<CellComponent>> GetBlocks(CellComponent cellComponent, Grid grid)
        {
            var points = new List<Vector2Int>();
            var blockDestroyPathIfo = cellComponent.ComponentContainer.Get<BombComponent>().BlockDestroyPathInfo;
            var color = GetColor(cellComponent, grid, blockDestroyPathIfo);
            if (color == null) yield break;
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

                    if (StepIsValid(grid, newStep, cellComponent) && color == GetBlockId(grid, newStep))
                    {
                        track[newStep] = point;
                        points.Add(newStep);
                        if(track[point] == _nullVector)
                            break;
                    }
                }

                if (queue.Count != 0) continue;
                var blocks = new List<CellComponent>();
                foreach (var item in points)
                {
                    blocks.Add(GetCellComponent(grid, item));
                    if (blockDestroyPathIfo.IsOneStep) continue;
                    queue.Enqueue(item);
                }

                points.Clear();
                yield return blocks;
            }
        }

        private string GetColor(CellComponent cellComponent, Grid grid, IBlockDestroyPathInfo blockDestroyPathIfo)
        {
            var colors = new Dictionary<string, int>();
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
                        var newColor = GetBlockId(grid, newStep);
                        var currentColor = GetBlockId(grid, point);
                        if (track[point] == _nullVector)
                        {
                            colors[newColor] = 1;
                            queue.Enqueue(newStep);
                            track[newStep] = point;
                        }

                        if (newColor != currentColor) continue;
                        colors[newColor] += 1;
                        queue.Enqueue(newStep);
                        track[newStep] = point;
                    }
                }
            }

            var counter = 0;
            string rezColor = null;
            foreach (var item in colors)
            {
                if (item.Value > counter)
                {
                    counter = item.Value;
                    rezColor = item.Key;
                }
            }

            return rezColor;
        }

        private CellComponent GetCellComponent(Grid grid, Vector2Int newStep)
        {
            return grid.Cells[newStep.x][newStep.y].CellComponent;
        }
        
        private static string GetBlockId(Grid grid, Vector2Int newStep)
        {
            var color = grid.Cells[newStep.x][newStep.y].CellComponent.ComponentContainer.ID;
            return color;
        }

        private static bool StepIsValid(Grid grid, Vector2Int stepVector, CellComponent cellComponent)
        {
            return InFieldRange(grid, stepVector, cellComponent) &&
                   ColorBlockStepValid(grid, stepVector);
        }

        private static bool ColorBlockStepValid(Grid grid, Vector2Int stepVector)
        {
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