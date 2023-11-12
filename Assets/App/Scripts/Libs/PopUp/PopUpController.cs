using System.Threading.Tasks;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Libs.PopUp
{
    public class PopUpController
    {
        private readonly LocalizationController _localizationController;
        private readonly PopUpContainer _popUpContainer = new();
        private PopUpView _currentPopup;

        public PopUpController(LocalizationController localizationController)
        {
            _localizationController = localizationController;
        }

        public async Task ShowPopup(string key)
        {
            var factory = _popUpContainer.GetPopup(key);
            var popup = factory.Create();
            await popup.ProcessShow();
        }

        public async Task HidePopup()
        {
            if (_currentPopup == null) return;

            await _currentPopup.ProcessHide();
        }

        public void AddPopup(string key, PopUpFactory popUpFactory)
        {
            popUpFactory.AddLocalization(_localizationController);
            _popUpContainer.AddPopUp(key, popUpFactory);
        }

        public void RemovePopups(params string[] keys)
        {
            _popUpContainer.RemovePopups(keys);
        }
    }
}