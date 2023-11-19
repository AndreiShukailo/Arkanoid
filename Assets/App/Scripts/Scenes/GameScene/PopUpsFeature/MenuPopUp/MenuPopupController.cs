using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.GameStates;

namespace App.Scripts.Scenes.StartScene.Language.PopUp
{
    public class MenuPopupController
    {
        private const string RestartButtonID = "VioletButton";
        private const string BackButtonID = "RedButton";
        private const string ContinueButtonID = "GreenButton";
        private const string RestartLanguageKey = "Restart";
        private const string BaskLanguageKey = "Back";
        private const string ContinueLanguageKey = "Continue";
        private readonly ButtonManager _buttonManager;
        private readonly CommandChangeState _commandChangeState;
        private readonly SceneLoaderController _sceneLoaderController;
        private readonly PopUpController _popUpController;

        public MenuPopupController(ButtonManager buttonManager,
            CommandChangeState commandChangeState, SceneLoaderController sceneLoaderController,
            PopUpController popUpController)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
            _sceneLoaderController = sceneLoaderController;
            _popUpController = popUpController;
        }

        public void ShowPopUp()
        {
            var popUp = _popUpController.Show<MenuPopUp>();
            BuildButtons(popUp);
            popUp.ProcessShow().Forget();
        }

        public async Task HidePopUp()
        {
            await _popUpController.Hide<MenuPopUp>();
        }

        private void BuildButtons(MenuPopUp menuPopUp)
        {
            _buttonManager.BuildButton(menuPopUp.Content, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);
            _buttonManager.BuildButton(menuPopUp.Content, OnBackButtonClick, BackButtonID, BaskLanguageKey);
            _buttonManager.BuildButton(menuPopUp.Content, OnContinueButtonClick, ContinueButtonID, ContinueLanguageKey);
        }

        private void OnRestartButtonClick() =>
            _commandChangeState.ChangeState<ReloadLevelState>();

        private void OnContinueButtonClick() =>
            _commandChangeState.ChangeState<StateProcessGame>();

        private void OnBackButtonClick() =>
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
    }
}