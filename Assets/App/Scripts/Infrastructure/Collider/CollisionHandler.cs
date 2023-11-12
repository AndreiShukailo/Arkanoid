using App.Scripts.Scenes.GameScene.Ball.View;
using UnityEngine;

namespace App.Scripts.Infrastructure.Collider
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private BallView _ballView;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<ICollidedItem>(out var collidedItem))
            {
                CorrectAngle(other);

                _ballView.OnCollide();
                collidedItem.OnCollide();
            }
        }

        private void CorrectAngle(Collision2D other)
        {
            var velocity = other.relativeVelocity * -1f; 
            var minBounceAngle = _ballView.MinBounceAngle;
            var fallNormalVector = other.contacts[0].normal;

            var angle = Mathf.Atan(velocity.y / velocity.x);
            Vector3 correctVector = velocity;
            
            if (Mathf.Abs(angle) < minBounceAngle * Mathf.Deg2Rad && angle != 0)
                correctVector = GetCorrectVector(minBounceAngle, velocity);
            else if(angle == 0)
                correctVector = GetCorrectVector(-minBounceAngle, velocity);
            
            if (Mathf.Abs(angle) > 90 * Mathf.Deg2Rad - minBounceAngle * Mathf.Deg2Rad)
                correctVector = GetCorrectVector(90f - minBounceAngle, velocity);

            velocity = correctVector;
            _ballView.Rigidbody.velocity = Vector2.Reflect(velocity, fallNormalVector);
        }

        private Vector3 GetCorrectVector(float correctAngle, Vector2 velocity)
        {
            float newY = Mathf.Tan(correctAngle * Mathf.Deg2Rad);
            var correctVector = new Vector3(1, newY, 0).normalized;
            correctVector *= _ballView.CurrentSpeed;
            correctVector.x *= Mathf.Sign(velocity.x);
            correctVector.y *= Mathf.Sign(velocity.y);

            return correctVector;
        }
    }
}