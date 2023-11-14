using System;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Infrastructure.LevelsManagement;
using App.Scripts.Libs.Localization;
using TMPro;
using UnityEngine;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View
{
    public class PackView : MonoBehaviour
    {
        public string Key; 
        [SerializeField] private ButtonView _buttonView;
        [SerializeField] protected LocalizedText _galaxyNameText;
        [SerializeField] private LocalizedText _galaxyText;
        [SerializeField] private TMP_Text _levelCountText;

        public virtual void Construct(Pack pack, LocalizationController localizationController, int levelsCount,
            Action onButtonClick)
        {
            InstallLocalization(pack, localizationController);
            InstallLevelsCountText(pack, levelsCount);
            InstallButton(onButtonClick);
        }

        private void InstallButton(Action onButtonClick)
        {
            if (_buttonView != null)
                _buttonView.Subscribe(onButtonClick);
        }

        private void InstallLevelsCountText(Pack pack, int levelsCount)
        {
            _levelCountText.text = $"{levelsCount}/{pack.LevelsCount}";
        }

        protected virtual void InstallLocalization(Pack pack, LocalizationController localizationController)
        {
            _galaxyNameText.Construct(localizationController);
            _galaxyText.Construct(localizationController);
        }
    }
}