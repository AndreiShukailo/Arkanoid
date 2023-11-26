using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;

namespace App.Scripts.Scenes.GameScene.Platform.Systems
{
    public class BulletFactory : PoolFactory<ComponentContainer>
    {
        private readonly SystemsContainer _systemsContainer;

        public BulletFactory(PoolSetting<ComponentContainer> poolSetting, SystemsContainer systemsContainer) : base(poolSetting)
        {
            _systemsContainer = systemsContainer;
        }

        public override ComponentContainer Create()
        {
            var bulletComponents =  _poolProvider.ObjectPool.Spawn();
            bulletComponents.Register(_systemsContainer);
            bulletComponents.AddToSystem<CollisionHandlerComponent>();
            bulletComponents.AddToSystem<DestroyWhenInvisibleComponent>();
            return bulletComponents;
        }
    }
}