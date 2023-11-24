using App.Scripts.Infrastructure.Extensions;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components
{
    public class DestroyWhenInvisibleComponent : Component
    {
        public Rect Rect => _spriteRenderer.GetRect();
        [SerializeField] private SpriteRenderer _spriteRenderer;
    }
}