using System.Collections.Generic;
using App.Scripts.Libs.Components;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Block.SimpleBlock.Components
{
    public class HealthViewComponent : Component
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private List<SpriteRenderer> _cracks;

        public override void Construct(ComponentContainer componentContainer)
        {
            base.Construct(componentContainer);
            _healthComponent.OnChangeHealth += ChangeHealth;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            _healthComponent.OnChangeHealth -= ChangeHealth;
        }

        private void ChangeHealth(float health)
        {
            UpdateCrackSize();
            var step = 1f / _cracks.Count;
            var point = 1f;

            for (var i = 0; i < _cracks.Count; i++)
            {
                _cracks[i].gameObject.SetActive(health < point);
                point -= step;
            }
        }

        private void UpdateCrackSize()
        {
            foreach (var crack in _cracks)
                crack.size = _spriteRenderer.size;
        }
    }
}