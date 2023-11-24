using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly DestroyWhenInvisibleSystem _destroyWhenInvisibleSystem;

        public HandlerClearLevel(LevelController levelController, DestroyWhenInvisibleSystem destroyWhenInvisibleSystem)
        {
            _levelController = levelController;
            _destroyWhenInvisibleSystem = destroyWhenInvisibleSystem;
        }

        public async Task Process()
        {
            _destroyWhenInvisibleSystem.ClearBoosts();
            await ClearLevelModel();
        }

        private async Task ClearLevelModel()
        {
            await _levelController.CleanupLevel();
        }
    }
}