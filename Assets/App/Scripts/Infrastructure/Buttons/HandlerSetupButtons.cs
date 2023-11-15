using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;

namespace App.Scripts.Scenes.StartScene.Buttons
{
    public abstract class HandlerSetupButtons : IHandlerSetupScene
    {
        protected readonly ButtonsContainer _buttonsContainer;
        protected readonly SceneLoaderController _sceneLoaderController;
        protected readonly CommandChangeState _commandChangeState;

        protected HandlerSetupButtons(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, CommandChangeState commandChangeState)
        {
            _buttonsContainer = buttonsContainer;
            _sceneLoaderController = sceneLoaderController;
            _commandChangeState = commandChangeState;
        }

        public Task Process()
        {
            InstallButtons();
            return Task.CompletedTask;
        }

        protected abstract void InstallButtons();
    }
}