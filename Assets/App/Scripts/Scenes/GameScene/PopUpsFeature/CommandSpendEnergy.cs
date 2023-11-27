using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp.View;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.PackSelectScene.Features.PopUpFeature;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature
{
    public class CommandSpendEnergy
    {
        private readonly EnergyController _energyController;
        private readonly EnergyViewController _energyViewController;
        private readonly CommandChangeState _commandChangeState;
        private readonly HealthController _healthController;
        private readonly NoEnergyPopUpController _noEnergyPopUpController;

        public CommandSpendEnergy(EnergyController energyController, EnergyViewController energyViewController,
            CommandChangeState commandChangeState,
            HealthController healthController, NoEnergyPopUpController noEnergyPopUpController)
        {
            _energyController = energyController;
            _energyViewController = energyViewController;
            _commandChangeState = commandChangeState;
            _healthController = healthController;
            _noEnergyPopUpController = noEnergyPopUpController;
        }

        public async Task ProcessSpendEnergy(PopUpView popUpView)
        {
            if (_energyController.StartLevel())
            {
                await _energyViewController.UpdateEnergy();
                _commandChangeState.ChangeState<ReloadLevelState>();
            }
            else
            {
                _noEnergyPopUpController.ShowPopUp();
            }
        }

        public async Task ProcessByHealth(PopUpView popUpView)
        {
            if (_energyController.ByHealth())
            {
                _healthController.ChangeHealth(1);
                await _energyViewController.UpdateEnergy();
                _commandChangeState.ChangeState<ReloadPlatformState>();
            }
            else
            {
                _noEnergyPopUpController.ShowPopUp();
            }
        }
    }
}