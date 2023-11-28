using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearLevel : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly SystemsContainer _systemsContainer;
        private readonly SystemsGroup _systemsGroup;

        public HandlerClearLevel(LevelController levelController, SystemsContainer systemsContainer, SystemsGroup systemsGroup)
        {
            _levelController = levelController;
            _systemsContainer = systemsContainer;
            _systemsGroup = systemsGroup;
        }

        public async Task Process()
        {
            _systemsContainer.CleanupSystems();
            await ClearLevelModel();
        }

        private async Task ClearLevelModel()
        {
            _levelController.CleanupPlatform();
            _systemsGroup.Update(Time.deltaTime);
            await _levelController.CleanupLevel();
        }
    }
}