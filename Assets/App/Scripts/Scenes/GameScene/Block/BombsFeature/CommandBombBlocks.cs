using System.Collections;
using System.Collections.Generic;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using UnityEngine;
using Grid = App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.Grid;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature
{
    public class CommandBombBlocks
    {
        private const string IronBlockId = "IronBlock";
        private const float SecondsDelay = 0.5f;
        private LevelController _levelController;

        public CommandBombBlocks(LevelController levelController)
        {
            _levelController = levelController;
        }

        public IEnumerator Process(BombComponent bombComponent)
        {
            foreach (var cellComponents in GetComponents(bombComponent))
            {
                yield return new WaitForSeconds(SecondsDelay);
                
                foreach (var cellComponent in cellComponents)
                {
                    if (cellComponent == null) continue;
                    var healthComponent = cellComponent.ComponentContainer.Get<HealthComponent>();
                    if (healthComponent != null)
                    {
                        healthComponent.CurrentHealth -= bombComponent.Damage;
                        cellComponent.ComponentContainer.AddToSystem<HealthComponent>();
                        continue;
                    }

                    if (cellComponent.ComponentContainer.ID == IronBlockId)
                    {
                        cellComponent.ComponentContainer.AddToSystem<DeathComponent>();
                        continue;
                    }

                    cellComponent.ComponentContainer.AddToSystem<BombComponent>();
                }
            }
        }

        private IEnumerable<List<CellComponent>> GetComponents(BombComponent bombComponent)
        {
            return bombComponent.BlocksGetter.GetBlocks(bombComponent.CellComponent, GetLevelGrid());
        }

        private Grid GetLevelGrid()
        {
            return _levelController.LevelModel.LevelGrid;
        }
    }
}