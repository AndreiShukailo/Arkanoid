using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp
{
    public class LosePopUpController
    {
        private const string RestartButtonID = "VioletButton";
        private const string RestartLanguageKey = "Restart";
        private const string MenuButtonId = "RedButton";
        private const string MenuLanguageKey = "Menu";
        private readonly ButtonManager _buttonManager;
        private readonly PopUpController _popUpController;
        private readonly EnergyViewController _energyViewController;
        private readonly CommandSpendEnergy _commandSpendEnergy;
        private readonly SceneLoaderController _sceneLoaderController;
        private LosePopup _popUpView;

        public LosePopUpController(ButtonManager buttonManager,
            PopUpController popUpController, EnergyViewController energyViewController,
            CommandSpendEnergy commandSpendEnergy, SceneLoaderController sceneLoaderController)
        {
            _buttonManager = buttonManager;
            _popUpController = popUpController;
            _energyViewController = energyViewController;
            _commandSpendEnergy = commandSpendEnergy;
            _sceneLoaderController = sceneLoaderController;
        }

        public async void ShowPopUp()
        {
            _popUpView = _popUpController.Show<LosePopup>();
            _energyViewController.CreateEnergy(_popUpView.EnergyContainer);
            _buttonManager.BuildButton(_popUpView.Content, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);
            _buttonManager.BuildButton(_popUpView.Content, OnMenuButtonClick, MenuButtonId, MenuLanguageKey);
            _popUpView.ByHealthButtonView.Subscribe(OnByHealthButtonClick);

            await _popUpView.ProcessShow();
        }

        private void OnMenuButtonClick()
        {
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
        }

        public async Task HidePopUp()
        {
            await _popUpController.Hide<LosePopup>();
            _energyViewController.Remove();
            _popUpView.ByHealthButtonView.Unsubscribe();
        }

        private void OnRestartButtonClick()
        {
            _commandSpendEnergy.ProcessSpendEnergy(_popUpView).Forget();
        }

        private void OnByHealthButtonClick()
        {
            _commandSpendEnergy.ProcessByHealth(_popUpView).Forget();
        }
    }
}