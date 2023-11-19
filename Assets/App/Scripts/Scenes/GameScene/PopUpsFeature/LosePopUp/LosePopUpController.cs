using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;
using App.Scripts.Scenes.GameScene.GameStates;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp
{
    public class LosePopUpController
    {
        private const string RestartButtonID = "VioletButton";
        private const string RestartLanguageKey = "Restart";
        private readonly ButtonManager _buttonManager;
        private readonly CommandChangeState _commandChangeState;
        private readonly PopUpController _popUpController;

        public LosePopUpController(ButtonManager buttonManager, CommandChangeState commandChangeState,
            PopUpController popUpController)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
            _popUpController = popUpController;
        }

        public async void ShowPopUp()
        {
            var popUpView = _popUpController.Show<LosePopup>();
            _buttonManager.BuildButton(popUpView.Content, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);

            await popUpView.ProcessShow();
        }

        public async Task HidePopUp()
        {
            await _popUpController.Hide<LosePopup>();
        }

        private void OnRestartButtonClick()
        {   
            _commandChangeState.ChangeState<ReloadLevelState>();
        }
    }
}