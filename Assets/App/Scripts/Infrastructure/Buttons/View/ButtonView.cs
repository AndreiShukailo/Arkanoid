using System;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure.Buttons
{
    public class ButtonView : SpawnableItemMono
    {
        public string ButtonId => _buttonId;
        
        [SerializeField] private string _buttonId;
        [SerializeField] private LocalizedText _localizedText;
        [SerializeField] private Button _button;
        
        public void SetLocalization(LocalizationController localizationController, string key = null)
        {
            if (key != null)
                _localizedText.AddKey(key);
            
            if (_localizedText.LocalizationController != null) return;
            _localizedText.Construct(localizationController);
        }

        public void Subscribe(Action onClick) =>
            _button.onClick.AddListener(() => onClick?.Invoke());

        public void Unsubscribe() =>
            _button.onClick.RemoveAllListeners();

        public void SetInteractable(bool interactable)
        {
            _button.interactable = interactable;
        }
    }
}