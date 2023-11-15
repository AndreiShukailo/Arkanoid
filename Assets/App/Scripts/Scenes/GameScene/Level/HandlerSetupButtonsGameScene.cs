using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.PopUp;

namespace App.Scripts.Scenes.GameScene.Level
{
    public class HandlerSetupButtonsGameScene : HandlerSetupButtons
    {
        private readonly PopUpController _popUpController;

        public HandlerSetupButtonsGameScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, PopUpController popUpController) : base(buttonsContainer,
            sceneLoaderController)
        {
            _popUpController = popUpController;
        }

        protected override void InstallButtons()
        {
            _buttonsContainer.SubscribeButton("Menu", OnMenuButtonClick);
        }

        private void OnMenuButtonClick()
        {
            _popUpController.ShowPopup("Menu");
        }
    }
}