using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Platform.Components
{
    public class BulletComponent : Component
    {
        public int Damage => _damage;
        [SerializeField] private int _damage;
    }
}