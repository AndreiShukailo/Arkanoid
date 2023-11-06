using App.Scripts.Infrastructure.Component;
using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball
{
    class BallCreator : IBallCreator
    {
        private readonly BallConfig _ballConfig;
        private readonly BallFactory _ballFactory;

        public BallCreator(BallConfig ballConfig, BallFactory ballFactory)
        {
            _ballConfig = ballConfig;
            _ballFactory = ballFactory;
        }

        public ComponentsContainer CreateBall()
        {
            var spawnContext = new BallSpawnContext(_ballConfig.StartPosition, _ballConfig.Speed * Vector2.up);
            return _ballFactory.Create(spawnContext);
        }
    }
}