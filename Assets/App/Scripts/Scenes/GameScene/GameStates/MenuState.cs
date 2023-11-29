using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.GameScene.PopUpsFeature.MenuPopUp;
using Task = System.Threading.Tasks.Task;

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

        public override async Task OnExitState()
        {
            await _menuPopupController.HidePopUp();
        }
    }
}