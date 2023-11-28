using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp
{
    public class VictoryPopUpController
    {
        private const string NextButtonID = "VioletButton";
        private const string NextLanguageKey = "Next";
        private readonly ButtonManager _buttonManager;
        private readonly CommandChangeState _commandChangeState;
        private readonly PopUpController _popUpController;
        private readonly SceneLoaderController _sceneLoaderController;
        private readonly EnergyViewController _energyViewController;
        private readonly CommandSpendEnergy _commandSpendEnergy;
        private VictoryPopUp _victoryPopUp;

        public VictoryPopUpController(ButtonManager buttonManager, CommandChangeState commandChangeState,
            PopUpController popUpController, SceneLoaderController sceneLoaderController,
            EnergyViewController energyViewController, CommandSpendEnergy commandSpendEnergy)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
            _popUpController = popUpController;
            _sceneLoaderController = sceneLoaderController;
            _energyViewController = energyViewController;
            _commandSpendEnergy = commandSpendEnergy;
        }

        public async Task ShowPopUp(LocalizationController localizationController, PackInfo packInfo, Pack pack)
        {
            _victoryPopUp = _popUpController.Show<VictoryPopUp>();
            _energyViewController.CreateEnergy(_victoryPopUp.EnergyContainer);
            _victoryPopUp.Construct(localizationController, packInfo, pack);

            await _victoryPopUp.ProcessShow();
        }

        public async Task AddButton(PackInfo packInfo)
        {
            var nextButton = _buttonManager.BuildButton(_victoryPopUp.Content, () => OnNextButtonClick(packInfo),
                NextButtonID,
                NextLanguageKey);
            await _victoryPopUp.ShowButton(nextButton);
        }

        public async Task ChangePackCount(PackInfo packInfo)
        {
            await _victoryPopUp.ChangeCurrentLevel(packInfo);
        }

        public async Task ChangePack(LocalizationController localizationController, PackInfo packInfo, Pack pack)
        {
            await _victoryPopUp.ChangePack(localizationController, packInfo, pack);
        }

        public async Task HidePopUp()
        {
            await _popUpController.Hide<VictoryPopUp>();
            _energyViewController.Remove();
        }

        private void OnNextButtonClick(PackInfo packInfo)
        {
            if (packInfo != null)
            {
                _commandSpendEnergy.ProcessSpendEnergy(_victoryPopUp).Forget();
                return;
            }

            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
        }
    }
}