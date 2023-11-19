using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.Localization;

namespace App.Scripts.Infrastructure.Buttons.Container
{
    [Serializable]
    public class ButtonsContainer
    {
        public List<KeyButton> _buttons = new ();

        private Dictionary<string, ButtonView> _keyButtons = new ();
        
        public void Register(LocalizationController localizationController)
        {
            foreach (var button in _buttons)
            {
                var view = button.ButtonView;
                view.SetLocalization(localizationController);
                _keyButtons[button.Key] = view;
            }
        }

        public void SubscribeButton(string key, Action action) =>
            _keyButtons[key].Subscribe(action);

        public void UnsubscribeButton(string key) =>
            _keyButtons[key].Unsubscribe();
    }
}