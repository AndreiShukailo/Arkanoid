using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Scenes.StartScene.StartStates;

namespace App.Scripts.Scenes.StartScene.Buttons
{
    public class HandlerSetupButtons : IHandlerSetupScene
    {
        private readonly ButtonsContainer _buttonsContainer;
        private readonly SceneLoaderController _sceneLoaderController;
        private readonly CommandChangeState _commandChangeState;

        public HandlerSetupButtons(ButtonsContainer buttonsContainer,
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

        private void InstallButtons()
        {
            _buttonsContainer.SubscribeButton("Play", ProcessLoadGameScene);
            _buttonsContainer.SubscribeButton("Language", OwenLanguagePopup);
        }

        private void ProcessLoadGameScene()
        {
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.GameScene);
        }

        private void OwenLanguagePopup()
        {
            _commandChangeState.ChangeState<ChoseLanguageState>();
        }
    }
}