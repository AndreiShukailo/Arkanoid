using System;
using System.Threading.Tasks;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp.View;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure.EnergyFeature.View
{
    public class EnergyView : SpawnableItemMono
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private RotatedEffectView _rotatedEffectView;
        [SerializeField] private TMP_Text _energyCount;
        [SerializeField] private TMP_Text _maxEnergy;
        [SerializeField] private TMP_Text _timer;

        private Transform _parent;

        public void Construct(float currenEnergy, float maxEnergy, Transform container)
        {
            transform.SetParent(container);
            _slider.value = currenEnergy / maxEnergy;
            _energyCount.text = $"{currenEnergy}";
            _maxEnergy.text = $"/{maxEnergy}";
        }

        public async Task UpdateEnergy(int currenEnergy, float maxEnergy)
        {
            var sliderValue = currenEnergy / maxEnergy;
            var slide = AnimateSlide(sliderValue);
            var text = AnimateText(currenEnergy);
            _rotatedEffectView.StartAnimation();
            await Task.WhenAll(slide, text);
        }

        private async Task AnimateText(int currentEnergy)
        {
            var sequence = DOTween.Sequence();
            var startCount = int.Parse(_energyCount.text);
            sequence.Append(_energyCount.DOCounter(startCount, currentEnergy, 0.5f))
                .SetUpdate(true);
            await sequence.AsyncWaitForCompletion();
        }

        private async Task AnimateSlide(float value)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_slider.DOValue(value, 0.5f)).SetUpdate(true);
            await sequence.AsyncWaitForCompletion();
        }

        public override void OnCreated(IObjectPool objectPool)
        {
            base.OnCreated(objectPool);
            _parent = transform.parent;
        }

        public override void OnDespawned()
        {
            base.OnDespawned();
            transform.SetParent(_parent);
            _rotatedEffectView.StopAnimation();
        }

        public void UpdateTimer(int time)
        {
            var ts = TimeSpan.FromSeconds(time);
            _timer.text = $"{ts.Minutes:d2}:{ts.Seconds:d2}";
        }
    }
}