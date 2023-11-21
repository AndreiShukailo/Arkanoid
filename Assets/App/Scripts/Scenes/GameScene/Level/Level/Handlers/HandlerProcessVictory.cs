using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Localization;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp;

namespace App.Scripts.Scenes.GameScene.Level.Level.Handlers
{
    public class HandlerProcessVictory : IHandlerSetupScene
    {
        private readonly PackController _packController;
        private readonly VictoryPopUpController _victoryPopUpController;
        private readonly LocalizationController _localizationController;
        private readonly EnergyViewController _energyViewController;

        public HandlerProcessVictory(PackController packController, VictoryPopUpController victoryPopUpController,
            LocalizationController localizationController, EnergyViewController energyViewController)
        {
            _packController = packController;
            _victoryPopUpController = victoryPopUpController;
            _localizationController = localizationController;
            _energyViewController = energyViewController;
        }

        public async Task Process()
        {
            var packInfo = new PackInfo(_packController.CurrentPack);

            var show = _victoryPopUpController.ShowPopUp(_localizationController, packInfo,
                _packController.GetPack(packInfo));
            _packController.NextLevel();

            await Task.WhenAll(show);
            await SetDelay();
            await _victoryPopUpController.ChangePackCount(packInfo);
            await _energyViewController.UpdateEnergy();
            await SetDelay();

            if (_packController.CurrentPack != null && packInfo.PackId != _packController.CurrentPack.PackId)
            {
                await _victoryPopUpController.ChangePack(_localizationController, _packController.CurrentPack,
                    _packController.GetPack(_packController.CurrentPack));
                await SetDelay();
            }

            await _victoryPopUpController.AddButton(_packController.CurrentPack);
        }

        private async Task SetDelay()
        {
            await Task.Delay(500);
        }
    }
}