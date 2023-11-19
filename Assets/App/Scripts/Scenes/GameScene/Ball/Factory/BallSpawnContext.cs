using App.Scripts.Libs.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallSpawnContext
    {
        public readonly ComponentContainer Platform;
        public Vector2 Position;

        public BallSpawnContext(ComponentContainer platform, Vector2 position)
        {
            Platform = platform;
            Position = position;
        }
    }
}