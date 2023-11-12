using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.Platform.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallSpawnContext
    {
        public PlatformModel PlatformModel;
        public Vector2 Position;
        public float Speed;
        public readonly float MinBounceAngle;

        public BallSpawnContext(PlatformModel platformModel, Vector2 position, float velocity, float minBounceAngle)
        {
            PlatformModel = platformModel;
            Position = position;
            Speed = velocity;
            MinBounceAngle = minBounceAngle;
        }
    }
}