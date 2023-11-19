using System;
using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class HealthComponent : Component
    {
        public event Action<float> OnChangeHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                OnChangeHealth?.Invoke((float)_currentHealth / _startHealth);
            }
        }

        [SerializeField] private int _startHealth;
        private int _currentHealth;

        public override void OnAdd()
        {
            base.OnAdd();
            CurrentHealth = _startHealth;
        }
    }
}