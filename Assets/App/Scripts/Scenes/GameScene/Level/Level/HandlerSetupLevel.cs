using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Platform;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public class HandlerSetupLevel : IHandlerSetupScene
    {
        private readonly ILevelCreator _levelCreator;
        private readonly IBallCreator _ballCreator;
        private readonly IPlatformCreator _platformCreator;

        public HandlerSetupLevel(ILevelCreator levelCreator, IBallCreator ballCreator, IPlatformCreator platformCreator)
        {
            _levelCreator = levelCreator;
            _ballCreator = ballCreator;
            _platformCreator = platformCreator;
        }

        public Task Process()
        {
            SetupLevel();
            return Task.CompletedTask;
        }

        private void SetupLevel()
        {
            var levelModel = _levelCreator.CreateLevel(1, 1);
            var platform = _platformCreator.CreatePlatform();
            var ball = _ballCreator.CreateBall(platform);
        }
    }
}