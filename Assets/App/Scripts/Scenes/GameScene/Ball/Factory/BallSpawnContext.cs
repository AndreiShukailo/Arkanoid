using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallSpawnContext
    {
        public Vector2 Position;
        public Vector2 Velocity;

        public BallSpawnContext(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }
    }
}