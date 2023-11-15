using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Scenes.StartScene.StartStates;

namespace App.Scripts.Scenes.StartScene.Buttons
{
    class HandlerSetupButtonsStartScene : HandlerSetupButtons
    {
        public HandlerSetupButtonsStartScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, CommandChangeState commandChangeState) : base(buttonsContainer,
            sceneLoaderController, commandChangeState)
        {
        }
        
        protected override void InstallButtons()
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