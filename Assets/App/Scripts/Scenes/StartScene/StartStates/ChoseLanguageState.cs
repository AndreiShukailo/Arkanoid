using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.StartScene.StartStates
{
    public class ChoseLanguageState : GameState
    {
        private const string PopupName = "Language"; 
        private readonly PopUpController _popUpController;

        public ChoseLanguageState(PopUpController popUpController)
        {
            _popUpController = popUpController;
        }

        public override void OnEnterState()
        {
            _popUpController.ShowPopup(PopupName).Forget();
        }

        public override void OnExitState()
        {
            _popUpController.HidePopup().Forget();
        }
    }
}