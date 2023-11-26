using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.PopUp;
using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerProcessSkipLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly PopUpController _popUpController;

        public HandlerProcessSkipLevel(LevelController levelController, PopUpController popUpController)
        {
            _levelController = levelController;
            _popUpController = popUpController;
        }

        public async Task Process()
        {
            _popUpController.BlockUI(true);
            
            foreach (var gridCell in _levelController.LevelModel.LevelGrid.Cells)
            {
                foreach (var cell in gridCell)
                {
                    var cellComponent = cell.CellComponent;
                    if (cellComponent == null) continue;
                    
                    await Task.Delay(50);
                    var healthComponent = cellComponent.ComponentContainer.Get<HealthComponent>();
                    if (healthComponent != null)
                    {
                        healthComponent.CurrentHealth -= 10;
                        cellComponent.ComponentContainer.AddToSystem<HealthComponent>();
                        continue;
                    }
                    
                    cellComponent.ComponentContainer.AddToSystem<BombComponent>();
                    cellComponent.ComponentContainer.AddToSystem<SpawnBoostComponent>();
                    cellComponent.ComponentContainer.AddToSystem<BoostActivatorComponent>();
                }
            }
        }
    }
}