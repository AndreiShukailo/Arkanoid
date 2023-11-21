using System.Threading.Tasks;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp.View;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp.View;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp
{
    public class VictoryPopUp : PopUpView
    {
        [SerializeField] private RotatedEffectView RotatedEffect;
        [SerializeField] private Image _packLogo;
        [SerializeField] private TMP_Text _levelCount;
        [SerializeField] private TMP_Text _currentLevel;
        [SerializeField] private LocalizedText _galaxy;
        [SerializeField] private LocalizedText _galaxyName;

        public void Construct(LocalizationController localizationController, PackInfo packInfo, Pack pack)
        {
            RotatedEffect.StartAnimation();
            InstallPack(localizationController, packInfo, pack);
        }

        public override void SetLocalization(LocalizationController localizationController)
        {
            base.SetLocalization(localizationController);
            if(_galaxy.LocalizationController != null) return;
            _galaxy.Construct(localizationController);
        }

        public async Task ShowButton(ButtonView buttonView)
        {
            var sequence = DOTween.Sequence();
            buttonView.gameObject.transform.localScale = Vector3.zero;
            sequence.Append(buttonView.gameObject.transform
                    .DOScale(Vector3.one, 0.3f))
                    .SetUpdate(true);
            await sequence.AsyncWaitForCompletion();
        }

        public async Task ChangeCurrentLevel(PackInfo packInfo)
        {
            await AnimateGraphic(_currentLevel, 0);
            _currentLevel.text = $"{packInfo.LastLevel}";
            await AnimateGraphic(_currentLevel, 1);
        }

        public async Task ChangePack(LocalizationController localizationController, PackInfo packInfo, Pack pack)
        {
            await AnimateLevelInfo(0);
            InstallPack(localizationController, packInfo, pack);
            await AnimateLevelInfo(1);
        }

        private async Task AnimateLevelInfo(int targetAlfa)
        {
            var logo = AnimateGraphic(_packLogo, targetAlfa);
            var packCount = AnimateGraphic(_levelCount, targetAlfa);
            var levelCount = AnimateGraphic(_currentLevel, targetAlfa);
            var galaxyName = AnimateGraphic(_galaxyName.Text, targetAlfa);
            await Task.WhenAll(logo, packCount, levelCount, galaxyName);
        }

        private void InstallPack(LocalizationController localizationController, PackInfo packInfo, Pack pack)
        {
            SetGalaxyName(localizationController, pack.Key);
            _packLogo.sprite = pack.Icon;
            _levelCount.text = $"{pack.LevelsCount}";
            _currentLevel.text = $"{packInfo.LastLevel - 1}";
        }

        private async Task AnimateGraphic(Graphic graphic, int targetAlfa)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(graphic.DOFade(targetAlfa, 0.3f)).SetUpdate(true);
            await sequence.AsyncWaitForCompletion();
        }

        private void SetGalaxyName(LocalizationController localizationController, string galaxyKey)
        {
            _galaxyName.AddKey(galaxyKey);
            if(_galaxyName.LocalizationController != null) return;
            _galaxyName.Construct(localizationController);
        }

        private void OnDisable()
        {
            RotatedEffect.StopAnimation();
        }
    }
}