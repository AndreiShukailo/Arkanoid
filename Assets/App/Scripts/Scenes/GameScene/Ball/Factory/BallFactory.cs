using App.Scripts.Infrastructure.Component;
using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Ball.View;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallFactory : IFactory<ComponentsContainer, BallSpawnContext>
    {
        private readonly CheckCameraBordersSystem _checkCameraBordersSystem;
        private readonly PoolProviderMono<BallView> _poolProvider;

        public BallFactory(PoolSetting<BallView> poolSetting, CheckCameraBordersSystem checkCameraBordersSystem)
        {
            _checkCameraBordersSystem = checkCameraBordersSystem;
            _poolProvider = new PoolProviderMono<BallView>(poolSetting);
        }

        public ComponentsContainer Create(BallSpawnContext spawnContext)
        {
            var ballView = _poolProvider.ObjectPool.Spawn();
            ballView.transform.position = spawnContext.Position;

            var physicalComponent =
                new PhysicalComponent(ballView.Rigidbody, ballView.Collider2D, spawnContext.Velocity);
            var checkCameraBordersComponent =
                new CheckCameraBordersComponent(physicalComponent, _checkCameraBordersSystem);

            var componentContainer = new ComponentsContainer(ballView);
            componentContainer.AddComponent(physicalComponent);
            componentContainer.AddComponent(checkCameraBordersComponent);

            return componentContainer;
        }
    }
}