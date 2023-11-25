using System.Threading.Tasks;
using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class LoseState : GameState
    {
        private readonly LosePopUpController _losePopupController;
        private readonly TimeManager _timeManager;

        public LoseState(LosePopUpController losePopupController, TimeManager timeManager)
        {
            _losePopupController = losePopupController;
            _timeManager = timeManager;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            
            _timeManager.SetPause(true);
            _losePopupController.ShowPopUp();
        }

        public override void OnExitState()
        {
            base.OnExitState();
            Exit().Forget();
        }

        private async Task Exit()
        {
            await _losePopupController.HidePopUp();
        }
    }
}