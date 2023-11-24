using App.Scripts.Infrastructure;
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

        public VictoryState(HandlerProcessVictory handlerProcessVictory, VictoryPopUpController victoryPopUpController, TimeManager timeManager)
        {
            _handlerProcessVictory = handlerProcessVictory;
            _victoryPopUpController = victoryPopUpController;
            _timeManager = timeManager;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            _timeManager.SetPause(true);
            _handlerProcessVictory.Process().Forget();
        }

        public override void OnExitState()
        {
            base.OnExitState();
            OnExit();
        }

        private async void OnExit()
        {
            await _victoryPopUpController.HidePopUp();
            _timeManager.SetPause(false);
        }
    }
}