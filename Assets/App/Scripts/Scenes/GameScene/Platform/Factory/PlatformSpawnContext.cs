using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform.Factory
{
    public class PlatformSpawnContext
    {
        public Vector2 Position;

        public PlatformSpawnContext(Vector2 position)
        {
            Position = position;
        }
    }
}