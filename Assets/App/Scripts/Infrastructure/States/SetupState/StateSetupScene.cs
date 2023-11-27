using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Infrastructure.States.SetupState
{
    public class StateSetupScene : GameState
    {
        private readonly IHandlerSetupScene _handlerSetup;
        private readonly SceneLoaderController _sceneLoaderController;
        private readonly ButtonManager _buttonManager;

        public StateSetupScene(IHandlerSetupScene handlerSetupScenes, SceneLoaderController sceneLoaderController, ButtonManager buttonManager)
        {
            _handlerSetup = handlerSetupScenes;
            _sceneLoaderController = sceneLoaderController;
            _buttonManager = buttonManager;
        }

        public override void OnEnterState()
        {
            ProcessSetupLevel().Forget();
        }

        public override Task OnExitState()
        {
            return Task.CompletedTask;
        }

        private async Task ProcessSetupLevel()
        {
            _buttonManager.UpdateCamera();
            await _handlerSetup.Process();
            await _sceneLoaderController.ProcessOpenCurrentScene();
            
            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}