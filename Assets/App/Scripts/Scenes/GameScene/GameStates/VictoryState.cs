using System.Threading.Tasks;
using App.Scripts.Infrastructure.TimeManagement;
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

        public VictoryState(HandlerProcessVictory handlerProcessVictory, VictoryPopUpController victoryPopUpController,
            TimeManager timeManager, HandlerTransitToVictory handlerTransitToVictory)
        {
            _handlerProcessVictory = handlerProcessVictory;
            _victoryPopUpController = victoryPopUpController;
            _timeManager = timeManager;
            _handlerTransitToVictory = handlerTransitToVictory;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            OnEnter().Forget();
        }

        public override void OnExitState()
        {
            base.OnExitState();
            OnExit().Forget();
        }

        private async Task OnEnter()
        {
            await _handlerTransitToVictory.Process();
            _timeManager.SetPause(true);
            await _handlerProcessVictory.Process();
        }

        private async Task OnExit()
        {
            await _victoryPopUpController.HidePopUp();
        }
    }
}