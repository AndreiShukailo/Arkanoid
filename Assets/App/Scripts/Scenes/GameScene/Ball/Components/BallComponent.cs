using App.Scripts.Infrastructure.Effects.View;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public class BallComponent : Component
    {
        public bool IsFire => _isFire;
        private bool _isFire;
        [SerializeField] private EffectView _fireEffect;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _boostColor;

        public void SetFire(bool isFire)
        {
            _spriteRenderer.color = isFire ? _boostColor : Color.white;
            _isFire = isFire;
            _fireEffect.gameObject.SetActive(isFire);
        }
    }
}