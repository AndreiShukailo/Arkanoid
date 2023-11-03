using TMPro;
using UnityEngine;

namespace App.Scripts.Libs.Localization
{
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _key;
        
        private LocalizationController _localizationController;

        public void Construct(LocalizationController localizationController)
        {
            _localizationController = localizationController;
            SubscribeOnLocalizationUpdates();
        }

        public void AddKey(string key)
        {
            _key = key;
        }

        private void SubscribeOnLocalizationUpdates()
        {
            OnUpdateLanguage();
            _localizationController.OnUpdateLanguage += OnUpdateLanguage;
        }

        private void OnUpdateLanguage()
        {
            _text.text = _localizationController.CurrentLanguage.GetWord(_key);
        }

        private void OnDestroy()
        {
            _localizationController.OnUpdateLanguage -= OnUpdateLanguage;
        }
    }
}