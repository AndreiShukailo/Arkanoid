using App.Scripts.Infrastructure;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.StartScene.Language.PopUp;

namespace App.Scripts.Scenes.GameScene.GameStates
{
    public class MenuState : GameState
    {
        private readonly MenuPopupController _menuPopupController;
        private readonly TimeManager _timeManager;

        public MenuState(MenuPopupController menuPopupController, TimeManager timeManager)
        {
            _menuPopupController = menuPopupController;
            _timeManager = timeManager;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            
            _timeManager.SetPause(true);
            _menuPopupController.ShowPopUp();
        }

        public override void OnExitState()
        {
            base.OnExitState();
            Exit();
        }

        private async void Exit()
        {
            await _menuPopupController.HidePopUp();
            _timeManager.SetPause(false);
        }
    }
}