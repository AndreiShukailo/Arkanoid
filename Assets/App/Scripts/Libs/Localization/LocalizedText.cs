using TMPro;
using UnityEngine;

namespace App.Scripts.Libs.Localization
{
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private string _key;
        private LocalizationController _localizationController;

        public void Construct(LocalizationController localizationController, string key)
        {
            _localizationController = localizationController;
            _key = key;
            SubscribeOnLocalizationUpdates();
        }
        
        private void SubscribeOnLocalizationUpdates()
        {
            _localizationController.OnUpdateLanguage += OnUpdateLanguage;
        }

        private void OnUpdateLanguage(ILocalizationProvider localizationProvider)
        {
            _text.text = localizationProvider.GetLocalizationText(_key);
        }
    }
}