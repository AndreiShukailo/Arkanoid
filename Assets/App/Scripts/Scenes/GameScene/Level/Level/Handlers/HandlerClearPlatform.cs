using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearPlatform : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly SystemsGroup _systemsGroup;

        public HandlerClearPlatform(LevelController levelController, SystemsGroup systemsGroup)
        {
            _levelController = levelController;
            _systemsGroup = systemsGroup;
        }

        public Task Process()
        {
            _levelController.CleanupPlatform();
            _systemsGroup.Update(Time.deltaTime);
            return Task.CompletedTask;
        }
    }
}