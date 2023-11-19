using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Platform.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Systems
{
    public class ControlMoveSystem : ComponentSystem<ControlMovementComponent>
    {
        private readonly InputSystem _inputSystem;

        public ControlMoveSystem(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        public override void OnUpdate(ControlMovementComponent component)
        {
            base.OnUpdate(component);
            if (_inputSystem.IsTouching)
                SetTouchDirection(component);
            else
                component.MovingComponent.Rigidbody2D.velocity = Vector2.zero;
        }

        private void SetTouchDirection(ControlMovementComponent component)
        {
            component.MovingComponent.Rigidbody2D.velocity =
                new(
                    Mathf.Clamp(_inputSystem.TouchPosition.x - component.transform.position.x, -1, 1) *
                    component.MovingComponent.CurrentSpeed, 0f);
        }
    }
}