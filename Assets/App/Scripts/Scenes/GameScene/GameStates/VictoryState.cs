using System.Threading.Tasks;
using App.Scripts.Infrastructure;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class VictoryState : GameState
    {
        private readonly PackController _packController;
        private readonly VictoryPopUpController _victoryPopUpController;
        private readonly LocalizationController _localizationController;
        private readonly TimeManager _timeManager;

        public VictoryState(PackController packController, VictoryPopUpController victoryPopUpController,
            LocalizationController localizationController, TimeManager timeManager)
        {
            _packController = packController;
            _victoryPopUpController = victoryPopUpController;
            _localizationController = localizationController;
            _timeManager = timeManager;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            OnEnter();
        }

        public override void OnExitState()
        {
            base.OnExitState();
            OnExit();
        }

        private async void OnExit()
        {
            await _victoryPopUpController.HidePopUp();
            _timeManager.SetPause(false);
        }

        private async void OnEnter()
        {
            _timeManager.SetPause(true);
            var packInfo = new PackInfo(_packController.CurrentPack);

            var show = _victoryPopUpController.ShowPopUp(_localizationController, packInfo,
                _packController.GetPack(packInfo));
            _packController.NextLevel();

            await Task.WhenAll(show);
            await SetDelay();
            await _victoryPopUpController.ChangePackCount(packInfo);
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