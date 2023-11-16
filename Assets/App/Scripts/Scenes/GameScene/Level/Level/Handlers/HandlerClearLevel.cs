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
            await _levelController.CleanupLevel();
        }
    }
}