using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Scenes.StartScene.Language.PopUp;

namespace App.Scripts.Scenes.StartScene.Buttons
{
    class HandlerSetupButtonsStartScene : HandlerSetupButtons
    {
        private readonly LanguagePopupController _languagePopupController;
        private readonly PackController _packController;

        public HandlerSetupButtonsStartScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, LanguagePopupController languagePopupController,
            PackController packController) : base(buttonsContainer,
            sceneLoaderController)
        {
            _languagePopupController = languagePopupController;
            _packController = packController;
        }

        protected override void InstallButtons()
        {
            _buttonsContainer.SubscribeButton("Play", OpenGame);
            _buttonsContainer.SubscribeButton("Language", OpenLanguagePopup);
        }

        private void OpenGame()
        {
            if (_packController.IsFirst)
            {
                _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.GameScene);
                return;
            }

            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
        }

        private void OpenLanguagePopup() =>
            _languagePopupController.ShowPopUp();
    }
}