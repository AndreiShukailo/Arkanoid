using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.StartScene.States;

namespace App.Scripts.Scenes.StartScene
{
    public class HandlerSetupButtons : IHandlerSetupScene
    {
        private readonly ButtonsContainer _buttonsContainer;
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoaderController _sceneLoaderController;

        public HandlerSetupButtons(ButtonsContainer buttonsContainer, GameStateMachine gameStateMachine,
            SceneLoaderController sceneLoaderController)
        {
            _buttonsContainer = buttonsContainer;
            _gameStateMachine = gameStateMachine;
            _sceneLoaderController = sceneLoaderController;
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
            _gameStateMachine.ChangeState<LoadSceneState>();
        }

        private void OwenLanguagePopup()
        {
            _gameStateMachine.ChangeState<ChoseLanguageState>();
        }
    }
}