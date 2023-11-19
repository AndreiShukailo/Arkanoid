using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Scenes.GameScene.GameStates;

namespace App.Scripts.Scenes.GameScene.Level
{
    public class HandlerSetupButtonsGameScene : HandlerSetupButtons
    {
        private readonly CommandChangeState _commandChangeState;

        public HandlerSetupButtonsGameScene(ButtonsContainer buttonsContainer,
            SceneLoaderController sceneLoaderController, CommandChangeState commandChangeState) : base(buttonsContainer,
            sceneLoaderController)
        {
            _commandChangeState = commandChangeState;
        }

        protected override void InstallButtons() =>
            _buttonsContainer.SubscribeButton("Menu", OnMenuButtonClick);

        private void OnMenuButtonClick() =>
            _commandChangeState.ChangeState<MenuState>();
    }
}