using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class ReloadLevelState : GameState
    {
        private IHandlerSetupScene _handlerSetup ;

        public ReloadLevelState(IHandlerSetupScene handlerSetup)
        {
            _handlerSetup = handlerSetup;
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
            await _handlerSetup.Process();

            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}