using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearPlatform : IHandlerSetupScene
    {
        private readonly LevelController _levelController;

        public HandlerClearPlatform(LevelController levelController)
        {
            _levelController = levelController;
        }

        public Task Process()
        {
            _levelController.BallContainer.Cleanup();
            _levelController.PlatformModel.Remove();
            return Task.CompletedTask;
        }
    }
}