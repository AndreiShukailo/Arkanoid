using App.Scripts.Scenes.GameScene.Platform.Components;
using UnityEngine;
using Component = App.Scripts.Libs.Components.Component;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public class MovingWithPlatformComponent : Component
    {
        public ControlMovementComponent Platform { get; private set; }
        [HideInInspector] public bool IsTouch;

        public void Construct(ControlMovementComponent platform)
        {
            if(Platform == null)
                Platform = platform;
        }

        public override void OnAdd()
        {
            base.OnAdd();
            IsTouch = false;
        }
    }
}