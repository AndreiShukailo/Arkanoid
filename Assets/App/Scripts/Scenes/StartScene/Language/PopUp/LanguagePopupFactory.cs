using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Scenes.StartScene.Language.PopUp
{
    public class LanguagePopupFactory : PopUpFactory
    {
        private const string ButtonID = "VioletButton";
        private const string LanguageKey = "LanguageName.";
        private readonly ButtonManager _buttonManager;
        private readonly CommandChangeState _commandChangeState;

        public LanguagePopupFactory(PoolSetting<PopUpView> poolSetting, ButtonManager buttonManager, CommandChangeState commandChangeState) :
            base(poolSetting)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
        }
        
        protected override PopUpView BuildPopup(PopUpView popUpView, LocalizationController localizationController)
        {
            foreach (var language in localizationController.LanguagesInfo.Languages)
            {
                var buttonView = _buttonManager.GetButton(ButtonID);
                buttonView.Construct(popUpView.Content, localizationController, LanguageKey + language);
                buttonView.Subscribe(() => OnButtonClick(localizationController, language));
            }

            return popUpView;
        }

        private void OnButtonClick(LocalizationController localizationController, string language)
        {
            localizationController.UpdateLocalization(language);
            _commandChangeState.ChangeState<StateProcessGame>();
        }
    }
}