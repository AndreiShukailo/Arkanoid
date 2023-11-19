using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Platform.Components;

namespace App.Scripts.Scenes.GameScene.Platform.Factory
{
    public class PlatformFactory : PoolFactory<ComponentContainer, PlatformSpawnContext>
    {
        private readonly SystemsContainer _systemsContainer;

        public PlatformFactory(PoolSetting<ComponentContainer> poolSetting, SystemsContainer systemsContainer) : base(poolSetting)
        {
            _systemsContainer = systemsContainer;
        }

        public override ComponentContainer Create(PlatformSpawnContext value)
        {
            var componentContainer = _poolProvider.ObjectPool.Spawn();
            componentContainer.transform.position = value.Position;
            componentContainer.Register(_systemsContainer);
            componentContainer.AddToSystem<MovingComponent>();
            componentContainer.AddToSystem<ControlMovementComponent>();

            return componentContainer;
        }
    }
}