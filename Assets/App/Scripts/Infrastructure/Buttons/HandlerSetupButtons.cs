using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;

namespace App.Scripts.Infrastructure.Buttons
{
    public abstract class HandlerSetupButtons : IHandlerSetupScene
    {
        protected readonly ButtonsContainer _buttonsContainer;
        protected readonly SceneLoaderController _sceneLoaderController;

        protected HandlerSetupButtons(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController)
        {
            _buttonsContainer = buttonsContainer;
            _sceneLoaderController = sceneLoaderController;
        }

        public Task Process()
        {
            InstallButtons();
            return Task.CompletedTask;
        }

        protected abstract void InstallButtons();
    }
}