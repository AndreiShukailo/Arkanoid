using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Libs.PopUp
{
    public class PopUpController
    {
        public string CurrentPopupKey { get; private set; }
        
        private readonly LocalizationController _localizationController;
        private readonly CommandChangeState _commandChangeState;
        private readonly PopUpContainer _popUpContainer = new();
        private PopUpView _currentPopup;

        public PopUpController(LocalizationController localizationController, CommandChangeState commandChangeState)
        {
            _localizationController = localizationController;
            _commandChangeState = commandChangeState;
        }

        public void ShowPopup(string key)
        {
            CurrentPopupKey = key;
            _commandChangeState.ChangeState<PopUpState>();
        }

        public async Task ProcessShow(string key)
        {
            var factory = _popUpContainer.GetPopup(key);
            var popup = factory.Create();
            await popup.ProcessShow();
            _currentPopup = popup;
        }

        public async Task HidePopup()
        {
            if (_currentPopup == null) return;

            await _currentPopup.ProcessHide();
            _currentPopup = null;
        }

        public void AddPopup(string key, PopUpFactory popUpFactory)
        {
            popUpFactory.AddLocalization(_localizationController);
            _popUpContainer.AddPopUp(key, popUpFactory);
        }

        public void RemovePopups()
        {
            _popUpContainer.RemovePopups();
        }
    }
}