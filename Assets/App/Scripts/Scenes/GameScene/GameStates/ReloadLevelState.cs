using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Infrastructure.UIMenegement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class ReloadLevelState : GameState
    {
        private readonly BlockUIController _blockUIController;
        private IHandlerSetupScene _handlerSetup ;

        public ReloadLevelState(IHandlerSetupScene handlerSetup, BlockUIController blockUIController)
        {
            _blockUIController = blockUIController;
            _handlerSetup = handlerSetup;
        }

        public override void OnEnterState()
        {
            _blockUIController.SetBlocked(true);
            ProcessSetupLevel().Forget();
        }

        public override Task OnExitState()
        {
            _blockUIController.SetBlocked(false);
            return Task.CompletedTask;
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetup.Process();

            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}