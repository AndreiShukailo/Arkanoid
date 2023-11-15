using System;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;
using App.Scripts.Scenes.GameScene.GameStates;

namespace App.Scripts.Scenes.StartScene.Language.PopUp
{
    public class MenuPopupFactory : PopUpFactory
    {
        private const string RestartButtonID = "VioletButton";
        private const string BackButtonID = "RedButton";
        private const string ContinueButtonID = "GreenButton";
        private const string RestartLanguageKey = "Restart";
        private const string BaskLanguageKey = "Back";
        private const string ContinueLanguageKey = "Continue";
        private readonly ButtonManager _buttonManager;
        private readonly CommandChangeState _commandChangeState;
        private readonly SceneLoaderController _sceneLoaderController;

        public MenuPopupFactory(PoolSetting<PopUpView> poolSetting, ButtonManager buttonManager,
            CommandChangeState commandChangeState, SceneLoaderController sceneLoaderController) :
            base(poolSetting)
        {
            _buttonManager = buttonManager;
            _commandChangeState = commandChangeState;
            _sceneLoaderController = sceneLoaderController;
        }

        protected override PopUpView BuildPopup(PopUpView popUpView, LocalizationController localizationController)
        {
            BuildButton(popUpView, localizationController, OnRestartButtonClick, RestartButtonID, RestartLanguageKey);
            BuildButton(popUpView, localizationController, OnBackButtonClick, BackButtonID, BaskLanguageKey);
            BuildButton(popUpView, localizationController,  OnContinueButtonClick, ContinueButtonID, ContinueLanguageKey);

            return popUpView;
        }

        private void BuildButton(PopUpView popUpView, LocalizationController localizationController, Action onButtonClick, string buttonId, string languageKey)
        {
            var buttonView = _buttonManager.GetButton(buttonId);
            buttonView.Construct(popUpView.Content, localizationController, languageKey);
            buttonView.Subscribe(onButtonClick);
        }

        private void OnRestartButtonClick()
        {
            _commandChangeState.ChangeState<ReloadLevelState>();
        }
        
        private void OnContinueButtonClick()
        {
            _commandChangeState.ChangeState<StateProcessGame>();
        }

        private void OnBackButtonClick()
        {
            _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.PackSelectedScene);
        }
    }
}