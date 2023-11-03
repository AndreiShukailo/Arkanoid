using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Localization
{
    [Serializable]
    public class LocalizationTextContainer
    {
        [SerializeField] private List<LocalizedText> _localizedTexts;

        public void Register(LocalizationController localizationController)
        {
            for (var i = 0; i < _localizedTexts.Count; i++)
            {
                _localizedTexts[i].Construct(localizationController);
            }
        }
    }
}