using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class CorrectAngleSystem : ComponentSystem<CorretionAngleComponent>
    {
        public override void OnUpdate(CorretionAngleComponent component)
        {
            base.OnUpdate(component);
            if (component.CollidedGameObject == null) return;
            CorrectAngle(component);
            component.ClearCollision();
        }

        private void CorrectAngle(CorretionAngleComponent component)
        {
            var moving = component.ComponentContainer.Get<MovingComponent>();
            var velocity = moving.Rigidbody2D.velocity;
            var minBounceAngle = component.MinBounceAngle;

            var angle = Mathf.Atan(velocity.y / velocity.x);
            Vector3 correctVector = velocity;

            if (Mathf.Abs(angle) < minBounceAngle * Mathf.Deg2Rad && angle != 0)
                correctVector = GetCorrectVector(minBounceAngle, velocity);
            else if (angle == 0)
                correctVector = GetCorrectVector(-minBounceAngle, velocity);

            if (Mathf.Abs(angle) > 90 * Mathf.Deg2Rad - minBounceAngle * Mathf.Deg2Rad)
                correctVector = GetCorrectVector(90f - minBounceAngle, velocity);

            velocity = correctVector;
            component.Rigidbody.velocity =
                velocity.normalized * moving.CurrentSpeed;
        }

        private Vector3 GetCorrectVector(float correctAngle, Vector2 velocity)
        {
            float newY = Mathf.Tan(correctAngle * Mathf.Deg2Rad);
            var correctVector = new Vector3(1, newY, 0).normalized;
            correctVector *= velocity.magnitude;
            correctVector.x *= Mathf.Sign(velocity.x);
            correctVector.y *= Mathf.Sign(velocity.y);

            return correctVector;
        }
    }
}