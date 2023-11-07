using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Factory;
using App.Scripts.Scenes.GameScene.Ball.Model;
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

        public BallModel CreateBall()
        {
            var spawnContext = new BallSpawnContext(_ballConfig.StartPosition,
                _ballConfig.StartSpeed, _ballConfig.MinBounceAngle);
            return _ballFactory.Create(spawnContext);
        }
    }
}