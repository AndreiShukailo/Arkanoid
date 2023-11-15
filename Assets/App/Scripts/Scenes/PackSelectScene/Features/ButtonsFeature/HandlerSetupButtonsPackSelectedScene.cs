using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.SceneManagement;

namespace App.Scripts.Scenes.PackSelectScene.Features.ButtonsFeature
{
    public class HandlerSetupButtonsPackSelectedScene : HandlerSetupButtons
    {
        public HandlerSetupButtonsPackSelectedScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController) : base(buttonsContainer,
            sceneLoaderController)
        {
        }

        protected override void InstallButtons()
        {
            _buttonsContainer.SubscribeButton("BackStart", ProcessLoadGameScene);
        }

        private void ProcessLoadGameScene()
        {
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.StartScene);
        }
    }
}