using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Ball.Model;
using App.Scripts.Scenes.GameScene.Ball.View;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallFactory : IFactory<BallModel, BallSpawnContext>
    {
        private readonly PoolProviderMono<BallView> _poolProvider;

        public BallFactory(PoolSetting<BallView> poolSetting)
        {
            _poolProvider = new PoolProviderMono<BallView>(poolSetting);
        }

        public BallModel Create(BallSpawnContext spawnContext)
        {
            var ballView = _poolProvider.ObjectPool.Spawn();
            ballView.Construct(spawnContext.Position, spawnContext.MinBounceAngle);
            var ballModel = new BallModel(spawnContext.PlatformModel, ballView, spawnContext.Speed);
            ballView.AddModel(ballModel);

            return ballModel;
        }
    }
}