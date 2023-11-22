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
                _currentHealth = Mathf.Clamp(value, 0, _startHealth);
                OnChangeHealth?.Invoke((float)_currentHealth / _startHealth);
            }
        }

        [SerializeField] private int _startHealth;
        private int _currentHealth;

        public override void Construct(ComponentContainer componentContainer)
        {
            base.Construct(componentContainer);
            CurrentHealth = _startHealth;
        }
    }
}