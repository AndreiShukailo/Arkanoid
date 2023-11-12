using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Infrastructure.States
{
    public class LoadSceneState : GameState
    {
        private SceneLoaderController _sceneLoaderController;

        public LoadSceneState(SceneLoaderController sceneLoaderController)
        {
            _sceneLoaderController = sceneLoaderController;
        }

        public override void OnEnterState()
        {
            _sceneLoaderController.ProcessLoadScene().Forget();   
        }
    }
}