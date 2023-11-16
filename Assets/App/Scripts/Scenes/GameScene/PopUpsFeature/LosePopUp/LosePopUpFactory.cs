using System;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;
using App.Scripts.Scenes.GameScene.GameStates;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp
{
    public class LosePopUpFactory : PopUpFactory
    {
        private const string RestartButtonID = "VioletButton";
        private const string RestartLanguageKey = "Restart";
        private readonly ButtonManager _buttonManager;
        private readonly CommandChangeState _commandChangeState;

        public LosePopUpFactory(PoolSetting<PopUpView> poolSetting, ButtonManager buttonManager,
            CommandChangeState commandChangeState) :
            base(poolSetting)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
        }

        protected override PopUpView BuildPopup(PopUpView popUpView, LocalizationController localizationController)
        {
            BuildButton(popUpView, localizationController, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);

            return popUpView;
        }

        private void BuildButton(PopUpView popUpView, LocalizationController localizationController,
            Action onButtonClick, string buttonId, string languageKey)
        {
            var buttonView = _buttonManager.GetButton(buttonId);
            buttonView.Construct(popUpView.Content, localizationController, languageKey);
            buttonView.Subscribe(onButtonClick);
        }

        private void OnRestartButtonClick()
        {
            _commandChangeState.ChangeState<ReloadLevelState>();
        }
    }
}