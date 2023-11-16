using System.Threading.Tasks;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.PackInfoFeature;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerSetupLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly ILevelCreator _levelCreator;
        private readonly PackController _packController;
        private readonly PackInfoController _packInfoController;
        private readonly HealthController _healthController;

        public HandlerSetupLevel(LevelController levelController, ILevelCreator levelCreator,
            PackController packController, PackInfoController packInfoController, HealthController healthController)
        {
            _levelController = levelController;
            _levelCreator = levelCreator;
            _packController = packController;
            _packInfoController = packInfoController;
            _healthController = healthController;
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
            
            _packInfoController.UpdatePackInfo();
            _healthController.ReloadHealth();

            var levelModel = _levelCreator.CreateLevel(_packController.CurrentPack, _levelController);
            _levelController.SetupLevel(levelModel);
        }
    }
}