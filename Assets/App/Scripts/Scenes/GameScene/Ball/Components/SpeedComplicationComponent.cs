using App.Scripts.Libs.Components;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public class SpeedComplicationComponent : Component
    {
        public float MaxSpeed => _maxSpeed;
        public MovingComponent MovingComponent => _movingComponent;
        [SerializeField] private MovingComponent _movingComponent;
        [SerializeField] private float _maxSpeed;
    }
}