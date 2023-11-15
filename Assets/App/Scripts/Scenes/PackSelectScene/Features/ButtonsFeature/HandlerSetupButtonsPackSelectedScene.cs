using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Scenes.StartScene.Buttons;

namespace App.Scripts.Scenes.PackSelectScene.Features.ButtonsFeature
{
    public class HandlerSetupButtonsPackSelectedScene : HandlerSetupButtons
    {
        public HandlerSetupButtonsPackSelectedScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, CommandChangeState commandChangeState) : base(buttonsContainer,
            sceneLoaderController, commandChangeState)
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