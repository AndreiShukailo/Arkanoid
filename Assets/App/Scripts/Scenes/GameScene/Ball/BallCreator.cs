using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public class BallCreator : IBallCreator
    {
        private readonly BallConfig _ballConfig;
        private readonly BallFactory _ballFactory;

        public BallCreator(BallConfig ballConfig, SystemsContainer systemsContainer)
        {
            _ballConfig = ballConfig;
            _ballFactory = new BallFactory(ballConfig.PoolSetting, systemsContainer);
        }

        public ComponentContainer CreateBall(ComponentContainer platform)
        {
            var ballPosition = new Vector2(0, platform.transform.position.y + _ballConfig.BallBottomOffset);

            var spawnContext = new BallSpawnContext(platform, ballPosition);
            return _ballFactory.Create(spawnContext);
        }
        
        public ComponentContainer CreateBall(Vector2 blockPosition)
        {
            var ballPosition = blockPosition;

            var spawnContext = new BallSpawnContext(ballPosition);
            return _ballFactory.Create(spawnContext);
        }
    }
}