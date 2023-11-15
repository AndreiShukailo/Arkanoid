using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Platform;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerSetupPlatform : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly IBallCreator _ballCreator;
        private readonly IPlatformCreator _platformCreator;

        public HandlerSetupPlatform(LevelController levelController, IBallCreator ballCreator, IPlatformCreator platformCreator)
        {
            _levelController = levelController;
            _ballCreator = ballCreator;
            _platformCreator = platformCreator;
        }

        public Task Process()
        {
            var platform = _platformCreator.CreatePlatform();
            var ball = _ballCreator.CreateBall(platform);
            
            _levelController.SetupPlatform(platform, ball);
            
            return Task.CompletedTask;
        }
    }
}