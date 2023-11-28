using System.Threading.Tasks;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerClearBall : IHandlerSetupScene
    {
        private readonly LevelController _levelController;
        private readonly SystemsGroup _systemsGroup;

        public HandlerClearBall(LevelController levelController, SystemsGroup systemsGroup)
        {
            _levelController = levelController;
            _systemsGroup = systemsGroup;
        }

        public Task Process()
        {
            _levelController.CleanupBall();
            _systemsGroup.Update(Time.deltaTime);
            return Task.CompletedTask;
        }
    }
}