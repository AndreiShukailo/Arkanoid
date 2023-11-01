using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Infrastructure.GameCore.States.SetupState
{
    public class StateSetupScene : GameState
    {
        private readonly IHandlerSetupScene _handlerSetup;
        private readonly SceneLoader _sceneLoader;

        public StateSetupScene(IHandlerSetupScene handlerSetupScenes, SceneLoader sceneLoader)
        {
            _handlerSetup = handlerSetupScenes;
            _sceneLoader = sceneLoader;
        }

        public override void OnEnterState()
        {
            ProcessSetupLevel().Forget();
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetup.Process();
            await _sceneLoader.ProcessOpenCurrentScene();

            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}