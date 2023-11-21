using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp.View;
using App.Scripts.Scenes.GameScene.GameStates;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature
{
    public class CommandSpendEnergy
    {
        private EnergyController _energyController;
        private EnergyViewController _energyViewController;
        private CommandChangeState _commandChangeState;
        private SceneLoaderController _sceneLoaderController;

        public CommandSpendEnergy(EnergyController energyController, EnergyViewController energyViewController,
            CommandChangeState commandChangeState, SceneLoaderController sceneLoaderController)
        {
            _energyController = energyController;
            _energyViewController = energyViewController;
            _commandChangeState = commandChangeState;
            _sceneLoaderController = sceneLoaderController;
        }

        public async Task ProcessSpendEnergy(PopUpView popUpView)
        {
            popUpView.SetBlock(true);
            if (_energyController.StartLevel())
            {
                await _energyViewController.UpdateEnergy();
                _commandChangeState.ChangeState<ReloadLevelState>();
            }
            else
            {
                _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
            }
        }
    }
}