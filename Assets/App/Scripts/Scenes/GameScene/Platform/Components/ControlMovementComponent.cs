using App.Scripts.Libs.Components;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Platform.Components
{
    public class ControlMovementComponent : Component
    {
        public MovingComponent MovingComponent => _movingComponent;
        [SerializeField] private MovingComponent _movingComponent;
    }
}