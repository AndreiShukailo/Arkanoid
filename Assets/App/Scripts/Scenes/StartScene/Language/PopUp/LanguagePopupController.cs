using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.StartScene.Language.PopUp
{
    public class LanguagePopupController
    {
        private const string ButtonID = "VioletButton";
        private const string LanguageKey = "LanguageName.";
        private readonly PopUpController _popUpController;
        private readonly LocalizationController _localizationController;
        private readonly ButtonManager _buttonManager;

        public LanguagePopupController(ButtonManager buttonManager, PopUpController popUpController,
            LocalizationController localizationController)
        {
            _buttonManager = buttonManager;
            _popUpController = popUpController;
            _localizationController = localizationController;
        }

        public async void ShowPopUp()
        {
            var popUp = _popUpController.Show<LanguagePopUp>();

            foreach (var language in _localizationController.LanguagesInfo.Languages)
            {
                _buttonManager.BuildButton(popUp.Content, () => OnButtonClick(language), ButtonID,
                    LanguageKey + language);
            }

            await popUp.ProcessShow();
            popUp.CloseLocalizationPopUp.Subscribe(() => Close(popUp.CloseLocalizationPopUp));
        }

        private void Close(ButtonView buttonView)
        {
            buttonView.Unsubscribe();
            _popUpController.Hide<LanguagePopUp>().Forget();
        }

        private void OnButtonClick(string language) =>
            _localizationController.UpdateLocalization(language);
    }
}