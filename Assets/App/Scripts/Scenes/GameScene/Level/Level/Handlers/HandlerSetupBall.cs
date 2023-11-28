using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerSetupBall : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly IBallCreator _ballCreator;

        public HandlerSetupBall(LevelController levelController, IBallCreator ballCreator)
        {
            _levelController = levelController;
            _ballCreator = ballCreator;
        }

        public Task Process()
        {
            var platform = _levelController.Platform;
            var ball = _ballCreator.CreateBall(platform);
            
            _levelController.SetupBall(ball);
            
            return Task.CompletedTask;
        }
    }
}