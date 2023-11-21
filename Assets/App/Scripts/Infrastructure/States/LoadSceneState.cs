using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
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

        public LoadSceneState(SceneLoaderController sceneLoaderController, PopUpController popUpController,
            EnergyViewController energyViewController)
        {
            _sceneLoaderController = sceneLoaderController;
            _popUpController = popUpController;
            _energyViewController = energyViewController;
        }

        public override void OnEnterState()
        {
            ProcessCloseScene().Forget();
        }

        private async Task ProcessCloseScene()
        {
            await _popUpController.HideAllPopups();
            await _sceneLoaderController.ProcessShowCurtain();
            _energyViewController.Remove();
            await _sceneLoaderController.LoadScene();
            StateMachine = null;
        }
    }
}