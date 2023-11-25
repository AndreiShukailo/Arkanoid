using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class SkipLevelState : GameState
    {
        private readonly IHandlerSetupScene _handlerSetupScene;

        public SkipLevelState(IHandlerSetupScene handlerSetupScene)
        {
            _handlerSetupScene = handlerSetupScene;
        }

        public override void OnEnterState()
        {
            ProcessSetupLevel().Forget();
            StateMachine.ChangeState<StateProcessGame>();
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetupScene.Process();
        }
    }
}