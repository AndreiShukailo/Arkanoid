using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.PopUpsFeature;

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
        private readonly EnergyViewController _energyViewController;
        private readonly CommandSpendEnergy _commandSpendEnergy;
        private MenuPopUp _popView;

        public MenuPopupController(ButtonManager buttonManager,
            CommandChangeState commandChangeState, SceneLoaderController sceneLoaderController,
            PopUpController popUpController, EnergyViewController energyViewController,
            CommandSpendEnergy commandSpendEnergy)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
            _sceneLoaderController = sceneLoaderController;
            _popUpController = popUpController;
            _energyViewController = energyViewController;
            _commandSpendEnergy = commandSpendEnergy;
        }

        public void ShowPopUp()
        {
            _popView = _popUpController.Show<MenuPopUp>();
            _energyViewController.CreateEnergy(_popView.EnergyContainer);
            BuildButtons(_popView);
            _popView.ProcessShow().Forget();
        }

        public async Task HidePopUp()
        {
            await _popUpController.Hide<MenuPopUp>();
            _energyViewController.Remove();
        }

        private void BuildButtons(MenuPopUp menuPopUp)
        {
            _buttonManager.BuildButton(menuPopUp.Content, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);
            _buttonManager.BuildButton(menuPopUp.Content, OnBackButtonClick, BackButtonID, BaskLanguageKey);
            _buttonManager.BuildButton(menuPopUp.Content, OnContinueButtonClick, ContinueButtonID, ContinueLanguageKey);
        }

        private void OnRestartButtonClick()
        {
            _commandSpendEnergy.ProcessSpendEnergy(_popView).Forget();
        }

        private void OnContinueButtonClick() =>
            _commandChangeState.ChangeState<StateProcessGame>();

        private void OnBackButtonClick() =>
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
    }
}