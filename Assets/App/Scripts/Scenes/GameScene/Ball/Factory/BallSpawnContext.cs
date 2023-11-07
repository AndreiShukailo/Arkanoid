using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallSpawnContext
    {
        public Vector2 Position;
        public float Speed;
        public readonly float MinBounceAngle;

        public BallSpawnContext(Vector2 position, float velocity, float minBounceAngle)
        {
            Position = position;
            Speed = velocity;
            MinBounceAngle = minBounceAngle;
        }
    }
}