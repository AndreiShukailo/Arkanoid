using System.Collections;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Effects;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using UnityEngine;
using Grid = App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.Grid;

namespace App.Scripts.Scenes.GameScene.Block.BombsFeature
{
    public class CommandBombBlocks
    {
        private const string IronBlockId = "IronBlock";
        private const float SecondsDelay = 0.2f;
        private LevelController _levelController;
        private readonly EffectViewFactory _effectViewFactory;

        public CommandBombBlocks(LevelController levelController, EffectViewFactory effectViewFactory)
        {
            _levelController = levelController;
            _effectViewFactory = effectViewFactory;
        }

        public IEnumerator Process(BombComponent bombComponent)
        {
            foreach (var cellComponents in GetComponents(bombComponent))
            {
                yield return new WaitForSeconds(SecondsDelay);
                
                foreach (var cellComponent in cellComponents)
                {
                    if (cellComponent == null) continue;
                    
                    _effectViewFactory.Create(cellComponent.transform.position);
                    
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
                    cellComponent.ComponentContainer.AddToSystem<SpawnBoostComponent>();
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