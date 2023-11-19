using System.Threading.Tasks;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerSetupLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly ILevelCreator _levelCreator;
        private readonly PackController _packController;

        public HandlerSetupLevel(LevelController levelController, ILevelCreator levelCreator,
            PackController packController)
        {
            _levelController = levelController;
            _levelCreator = levelCreator;
            _packController = packController;
        }

        public Task Process()
        {
            SetupLevel();
            return Task.CompletedTask;
        }

        private void SetupLevel()
        {
            if (_packController.CurrentPack == null)
                _packController.SetLastPack();

            var levelModel = _levelCreator.CreateLevel(_packController.CurrentPack, _levelController);
            _levelController.SetupLevel(levelModel);
        }
    }
}