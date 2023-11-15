using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;

namespace App.Scripts.Scenes.StartScene.Buttons
{
    class HandlerSetupButtonsStartScene : HandlerSetupButtons
    {
        private readonly PopUpController _popUpController;

        public HandlerSetupButtonsStartScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, PopUpController popUpController) : base(buttonsContainer,
            sceneLoaderController)
        {
            _popUpController = popUpController;
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
            _popUpController.ShowPopup("Language");
        }
    }
}