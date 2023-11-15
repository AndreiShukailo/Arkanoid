using System;

namespace App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller
{
    public class HealthController
    {
        public int Health { get; private set; }

        public Action OnUpdateHealth;

        private readonly int _startHealthCount;

        public HealthController(int startHealthCount)
        {
            _startHealthCount = startHealthCount;
            Health = _startHealthCount;
        }

        public void RemoveHealth()
        {
            if (Health <= 0) return;
            Health--;
            
            OnUpdateHealth?.Invoke();
        }

        public void ReloadHealth()
        {
            Health = _startHealthCount;
            
            OnUpdateHealth?.Invoke();
        }
    }
}