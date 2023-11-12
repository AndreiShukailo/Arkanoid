using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;

        public HandlerClearLevel(LevelController levelController)
        {
            _levelController = levelController;
        }

        public async Task Process()
        {
            await ClearLevelModel();
        }

        private async Task ClearLevelModel()
        {
            var cells = _levelController.LevelModel.LevelGrid.Cells;
            for (int i = 0; i < cells.Length; i++)
            for (int j = 0; j < cells[i].Length; j++)
            {
                cells[i][j].Block?.Remove();
                await Task.Yield();
            }
            
            _levelController.PlatformModel.Remove();
            await Task.Yield();
        }
    }
}