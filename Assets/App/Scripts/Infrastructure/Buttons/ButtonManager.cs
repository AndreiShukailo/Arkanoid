using System;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.Localization;
using UnityEngine;

namespace App.Scripts.Infrastructure.Buttons
{
    public class ButtonManager
    {
        private readonly ButtonsViewContainer _buttonsViewContainer;
        private readonly LocalizationController _localizationController;

        public ButtonManager(ButtonsViewContainer buttonsViewContainer, LocalizationController localizationController)
        {
            _localizationController = localizationController;
            _buttonsViewContainer = buttonsViewContainer;
            _buttonsViewContainer.Register();
        }

        public ButtonView BuildButton(Transform parent,
            Action onButtonClick, string buttonId, string languageKey)
        {
            var buttonView = GetButton(buttonId);
            buttonView.Construct(parent, _localizationController, languageKey);
            buttonView.Subscribe(onButtonClick);

            return buttonView;
        }

        public ButtonView GetButton(string key)
        {
            return _buttonsViewContainer.GetFactory(key).Create();
        }
        
        public void UpdateCamera()
        {
            _buttonsViewContainer.UpdateCamera();
        }
    }
}