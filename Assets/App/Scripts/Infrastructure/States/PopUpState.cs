using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using UnityEngine;

namespace App.Scripts.Infrastructure.States
{
    public class PopUpState : GameState
    {
        private readonly PopUpController _popUpController;

        public PopUpState(PopUpController popUpController)
        {
            _popUpController = popUpController;
        }

        public override void OnEnterState()
        {
            Time.timeScale = 0;
            _popUpController.ProcessShow(_popUpController.CurrentPopupKey).Forget();
        }

        public override void OnExitState()
        {
            Time.timeScale = 1;
            _popUpController.HidePopup().Forget();
        }
    }
}