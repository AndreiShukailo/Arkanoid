using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.SceneManagement;

namespace App.Scripts.Scenes.PackSelectScene.Features.ButtonsFeature
{
    public class HandlerSetupButtonsPackSelectedScene : HandlerSetupButtons
    {
        private const string BackButtonKey = "BackStart";

        public HandlerSetupButtonsPackSelectedScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController) : base(buttonsContainer,
            sceneLoaderController)
        {
        }

        protected override void InstallButtons()
        {
            _buttonsContainer.SubscribeButton(BackButtonKey, ProcessLoadGameScene);
        }

        public void UnSubscribe()
        {
            _buttonsContainer.UnsubscribeButton(BackButtonKey);
        }

        private void ProcessLoadGameScene()
        {
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.StartScene);
        }
    }
}