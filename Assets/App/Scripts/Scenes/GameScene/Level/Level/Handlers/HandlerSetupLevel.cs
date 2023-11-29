using System.Threading.Tasks;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.LevelProgressInfo;
using App.Scripts.Scenes.GameScene.Platform;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerSetupLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly ILevelCreator _levelCreator;
        private readonly PackController _packController;
        private readonly IPlatformCreator _platformCreator;
        private readonly LevelProgressInfoController _levelProgressInfoController;

        public HandlerSetupLevel(LevelController levelController, ILevelCreator levelCreator,
            PackController packController, IPlatformCreator platformCreator, LevelProgressInfoController levelProgressInfoController)
        {
            _levelController = levelController;
            _levelCreator = levelCreator;
            _packController = packController;
            _platformCreator = platformCreator;
            _levelProgressInfoController = levelProgressInfoController;
        }

        public async Task Process()
        {
            await SetupLevel();
        }

        private async Task SetupLevel()
        {
            if (_packController.CurrentPack == null)
                _packController.SetLastPack();

            
            _levelProgressInfoController.UpdatePackInfo();
            var levelModelTask = _levelCreator.CreateLevel(_packController.CurrentPack, _levelController);
            await levelModelTask;
            _levelController.SetupLevel(levelModelTask.Result);
            _levelController.SetupPlatform(_platformCreator.CreatePlatform());
        }
    }
}