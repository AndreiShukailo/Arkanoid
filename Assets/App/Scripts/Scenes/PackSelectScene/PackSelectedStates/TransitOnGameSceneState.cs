using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.PackSelectScene.Features.ButtonsFeature;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature;

namespace App.Scripts.Scenes.PackSelectScene.PackSelectedStates
{
    public class TransitOnGameSceneState : GameState
    {
        private readonly EnergyViewController _energyViewController;
        private readonly SceneLoaderController _sceneLoaderController;
        private readonly HandlerSetupButtonsPackSelectedScene _handlerSetupButtonsPackSelectedScene;
        private PacksCreator _packCreator;

        public TransitOnGameSceneState(EnergyViewController energyViewController,
            SceneLoaderController sceneLoaderController,
            HandlerSetupButtonsPackSelectedScene handlerSetupButtonsPackSelectedScene,
            PacksCreator packCreator)
        {
            _energyViewController = energyViewController;
            _sceneLoaderController = sceneLoaderController;
            _handlerSetupButtonsPackSelectedScene = handlerSetupButtonsPackSelectedScene;
            _packCreator = packCreator;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            ProcessOpenScene().Forget();
        }

        private async Task ProcessOpenScene()
        {
            _packCreator.Cleanup();
            _handlerSetupButtonsPackSelectedScene.UnSubscribe();
            await _energyViewController.UpdateEnergy();
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.GameScene);
        }
    }
}