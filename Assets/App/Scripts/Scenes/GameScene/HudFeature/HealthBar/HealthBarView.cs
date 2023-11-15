using System.Collections.Generic;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.HudFeature.HealthBar
{
    public class HealthBarView : MonoBehaviour
    {
        private readonly List<HealthItemView> _healthItems = new();
        private HealthController _healthController;

        public void Construct(HealthController healthController, HealthItemFactory healthItemFactory)
        {
            _healthController = healthController;
            CreateHealthItems(healthItemFactory);
            _healthController.OnUpdateHealth += UpdateHealth;
        }

        private void UpdateHealth()
        {
            var deactiveHealth = _healthItems.Count - _healthController.Health;

            foreach (var healthItem in _healthItems)
            {
                var isActive = deactiveHealth <= 0;

                healthItem.SetActive(isActive);
                deactiveHealth--;
            }
        }

        private void CreateHealthItems(HealthItemFactory healthItemFactory)
        {
            for (int i = 0; i < _healthController.Health; i++)
            {
                _healthItems.Add(healthItemFactory.Create());
            }
        }
    }
}