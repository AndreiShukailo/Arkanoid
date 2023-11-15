using System;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Libs.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View
{
    class PackViewActive : PackView
    {
        [SerializeField] private Image _icon;

        public override void Construct(Pack pack, LocalizationController localizationController, int levelsCount,
            Action onButtonClick)
        {
            base.Construct(pack, localizationController, levelsCount, onButtonClick);
            InstallIcon(pack);
        }

        private void InstallIcon(Pack pack)
        {
            _icon.sprite = pack.Icon;
        }

        protected override void InstallLocalization(Pack pack, LocalizationController localizationController)
        {
            base.InstallLocalization(pack, localizationController);
            _galaxyNameText.AddKey(pack.Key);
        }
    }
}