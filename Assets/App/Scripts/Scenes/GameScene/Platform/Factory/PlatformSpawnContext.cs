using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Factory
{
    public class PlatformSpawnContext
    {
        public Vector2 Position;
        public readonly float StartSpeed;

        public PlatformSpawnContext(Vector2 position, float startSpeed)
        {
            Position = position;
            StartSpeed = startSpeed;
        }
    }
}