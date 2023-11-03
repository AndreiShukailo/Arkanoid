using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Infrastructure.States.SetupState
{
    public class StateSetupScene : GameState
    {
        private readonly IHandlerSetupScene _handlerSetup;
        private readonly SceneLoaderController _sceneLoaderController;

        public StateSetupScene(IHandlerSetupScene handlerSetupScenes, SceneLoaderController sceneLoaderController)
        {
            _handlerSetup = handlerSetupScenes;
            _sceneLoaderController = sceneLoaderController;
        }

        public override void OnEnterState()
        {
            ProcessSetupLevel().Forget();
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetup.Process();
            await _sceneLoaderController.ProcessOpenCurrentScene();

            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}