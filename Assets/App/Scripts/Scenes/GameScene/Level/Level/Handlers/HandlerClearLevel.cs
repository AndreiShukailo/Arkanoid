using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly SystemsContainer _systemsContainer;

        public HandlerClearLevel(LevelController levelController, SystemsContainer systemsContainer)
        {
            _levelController = levelController;
            _systemsContainer = systemsContainer;
        }

        public async Task Process()
        {
            _systemsContainer.CleanupSystems();
            await ClearLevelModel();
        }

        private async Task ClearLevelModel()
        {
            await _levelController.CleanupLevel();
        }
    }
}