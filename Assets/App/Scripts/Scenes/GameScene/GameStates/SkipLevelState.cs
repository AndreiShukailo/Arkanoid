using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Infrastructure.UIMenegement;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Libs.StateMachine;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class SkipLevelState : GameState
    {
        private readonly IHandlerSetupScene _handlerSetupScene;
        private readonly BlockUIController _blockUIController;

        public SkipLevelState(IHandlerSetupScene handlerSetupScene, BlockUIController blockUIController)
        {
            _handlerSetupScene = handlerSetupScene;
            _blockUIController = blockUIController;
        }

        public override void OnEnterState()
        {
            _blockUIController.SetBlocked(true);
            ProcessSetupLevel().Forget();
            StateMachine.ChangeState<StateProcessGame>();
        }

        public override Task OnExitState()
        {
            return Task.CompletedTask;
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetupScene.Process();
        }
    }
}