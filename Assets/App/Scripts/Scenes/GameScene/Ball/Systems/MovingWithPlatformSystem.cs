using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public class MovingWithPlatformSystem : ComponentSystem<MovingWithPlatformComponent>
    {
        private readonly InputSystem _inputSystem;

        public MovingWithPlatformSystem(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        public override void OnUpdate(MovingWithPlatformComponent component)
        {
            base.OnUpdate(component);

            if (_inputSystem.IsTouching)
            {
                component.IsTouch = true;
                var transform = component.transform;
                transform.position =
                    new Vector3(component.Platform.transform.position.x, transform.position.y, 0f);
            }
            else if (component.IsTouch)
            {
                Remove(component);
                SetUpDirection(component);
            }
        }

        private void SetUpDirection(MovingWithPlatformComponent component)
        {
            var movingComponent = component.ComponentContainer.Get<MovingComponent>();
            if (movingComponent == null) return;

            movingComponent.Rigidbody2D.velocity = Vector2.up * movingComponent.CurrentSpeed;
        }
    }
}