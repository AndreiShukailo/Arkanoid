using TMPro;
using UnityEngine;

namespace App.Scripts.Libs.Localization
{
    public class LocalizedText : MonoBehaviour
    {
        public TMP_Text Text => _text;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _key;

        public LocalizationController LocalizationController { get; private set; }

        public void Construct(LocalizationController localizationController)
        {
            LocalizationController = localizationController;
            SubscribeOnLocalizationUpdates();
        }

        public void AddKey(string key)
        {
            _key = key;
            OnUpdateLanguage();
        }

        private void SubscribeOnLocalizationUpdates()
        {
            OnUpdateLanguage();
            LocalizationController.OnUpdateLanguage += OnUpdateLanguage;
        }

        private void OnUpdateLanguage()
        {
            _text.text = LocalizationController?.CurrentLanguage.GetWord(_key);
        }

        private void OnDestroy()
        {
            if(LocalizationController == null) return;
            LocalizationController.OnUpdateLanguage -= OnUpdateLanguage;
        }
    }
}