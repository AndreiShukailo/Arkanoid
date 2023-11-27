using System.Threading.Tasks;
using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Infrastructure.UIMenegement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.Level.Level.Handlers;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class VictoryState : GameState
    {
        private readonly HandlerProcessVictory _handlerProcessVictory;
        private readonly VictoryPopUpController _victoryPopUpController;
        private readonly TimeManager _timeManager;
        private readonly HandlerTransitToVictory _handlerTransitToVictory;
        private readonly BlockUIController _blockUIController;

        public VictoryState(HandlerProcessVictory handlerProcessVictory, VictoryPopUpController victoryPopUpController,
            TimeManager timeManager, HandlerTransitToVictory handlerTransitToVictory, BlockUIController blockUIController)
        {
            _handlerProcessVictory = handlerProcessVictory;
            _victoryPopUpController = victoryPopUpController;
            _timeManager = timeManager;
            _handlerTransitToVictory = handlerTransitToVictory;
            _blockUIController = blockUIController;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            _blockUIController.SetBlocked(true);
            OnEnter().Forget();
        }

        public override async Task OnExitState()
        {
            await _victoryPopUpController.HidePopUp();
            _blockUIController.SetBlocked(false);
        }

        private async Task OnEnter()
        {
            await _handlerTransitToVictory.Process();
            _timeManager.SetPause(true);
            await _handlerProcessVictory.Process();
        }
    }
}