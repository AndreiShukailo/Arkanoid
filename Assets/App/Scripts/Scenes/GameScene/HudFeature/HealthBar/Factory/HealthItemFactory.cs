using App.Scripts.Libs.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Factory
{
    public class HealthItemFactory : IFactory<HealthItemView>
    {
        private readonly int _startHealthCount;
        private readonly HealthItemView _healthItemView;
        private readonly HealthBarView _healthBarView;

        public HealthItemFactory(HealthItemView healthItemView, HealthBarView healthBarView)
        {
            _healthItemView = healthItemView;
            _healthBarView = healthBarView;
        }

        public HealthItemView Create()
        {
            return Object.Instantiate(_healthItemView, _healthBarView.transform);
        }
    }
}