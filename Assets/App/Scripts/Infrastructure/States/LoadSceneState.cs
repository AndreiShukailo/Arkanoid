using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Infrastructure.States
{
    public class LoadSceneState : GameState
    {
        private readonly SceneLoaderController _sceneLoaderController;
        private readonly PopUpController _popUpController;
        private readonly EnergyViewController _energyViewController;
        private readonly TimeManager _timeManager;

        public LoadSceneState(SceneLoaderController sceneLoaderController, PopUpController popUpController,
            EnergyViewController energyViewController, TimeManager timeManager)
        {
            _sceneLoaderController = sceneLoaderController;
            _popUpController = popUpController;
            _energyViewController = energyViewController;
            _timeManager = timeManager;
        }

        public override void OnEnterState()
        {
            _timeManager.SetPause(true);
            ProcessCloseScene().Forget();
        }

        public override Task OnExitState()
        {
            return Task.CompletedTask;
        }

        private async Task ProcessCloseScene()
        {
            await _popUpController.HideAllPopups();
            await _sceneLoaderController.ProcessShowCurtain();
            _timeManager.SetPause(false);
            _energyViewController.Remove();
            await _sceneLoaderController.LoadScene();
            StateMachine = null;
        }
    }
}