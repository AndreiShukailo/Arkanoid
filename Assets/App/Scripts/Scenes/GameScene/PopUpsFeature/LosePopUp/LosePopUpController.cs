using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp
{
    public class LosePopUpController
    {
        private const string RestartButtonID = "VioletButton";
        private const string RestartLanguageKey = "Restart";
        private readonly ButtonManager _buttonManager;
        private readonly PopUpController _popUpController;
        private readonly EnergyViewController _energyViewController;
        private readonly CommandSpendEnergy _commandSpendEnergy;
        private LosePopup _popUpView;

        public LosePopUpController(ButtonManager buttonManager,
            PopUpController popUpController, EnergyViewController energyViewController, CommandSpendEnergy commandSpendEnergy)
        {
            _buttonManager = buttonManager;
            _popUpController = popUpController;
            _energyViewController = energyViewController;
            _commandSpendEnergy = commandSpendEnergy;
        }

        public async void ShowPopUp()
        {
            _popUpView = _popUpController.Show<LosePopup>();
            _energyViewController.CreateEnergy(_popUpView.EnergyContainer);
            _buttonManager.BuildButton(_popUpView.Content, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);

            await _popUpView.ProcessShow();
        }

        public async Task HidePopUp()
        {
            await _popUpController.Hide<LosePopup>();
            _energyViewController.Remove();
        }

        private void OnRestartButtonClick()
        {
            _commandSpendEnergy.ProcessSpendEnergy(_popUpView).Forget();
        }
    }
}