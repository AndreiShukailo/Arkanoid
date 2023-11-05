using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public class HandlerSetupLevel : IHandlerSetupScene
    {
        private readonly ILevelCreator _levelCreator;

        public HandlerSetupLevel(ILevelCreator levelCreator)
        {
            _levelCreator = levelCreator;
        }

        public Task Process()
        {
            SetupLevel();
            return Task.CompletedTask;
        }

        private void SetupLevel()
        {
            var levelModel = _levelCreator.CreateLevel(1, 1);
        }
    }
}