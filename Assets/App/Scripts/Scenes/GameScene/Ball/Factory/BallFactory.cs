using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Platform.Components;

namespace App.Scripts.Scenes.GameScene.Ball.Factory
{
    public class BallFactory : PoolFactory<ComponentContainer, BallSpawnContext>
    {
        private readonly SystemsContainer _systemsContainer;

        public BallFactory(PoolSetting<ComponentContainer> poolSetting, SystemsContainer systemsContainer) : base(
            poolSetting)
        {
            _systemsContainer = systemsContainer;
        }

        public override ComponentContainer Create(BallSpawnContext spawnContext)
        {
            var componentContainer = _poolProvider.ObjectPool.Spawn();
            componentContainer.transform.position = spawnContext.Position;
            componentContainer.Register(_systemsContainer);
            componentContainer.AddToSystem<CollisionHandlerComponent>();
            componentContainer.AddToSystem<CorretionAngleComponent>();
            componentContainer.Get<MovingWithPlatformComponent>()
                .Construct(spawnContext.Platform.Get<ControlMovementComponent>());
            componentContainer.AddToSystem<MovingWithPlatformComponent>();
            componentContainer.AddToSystem<SpeedComplicationComponent>();

            return componentContainer;
        }
    }
}