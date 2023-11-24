using App.Scripts.Libs.Components;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature
{
    public class BoostFactory : PoolFactory<ComponentContainer, Vector3>
    {
        private SystemsContainer _systemsContainer;

        public BoostFactory(PoolSetting<ComponentContainer> poolSetting, SystemsContainer systemsContainer) : base(poolSetting)
        {
            _systemsContainer = systemsContainer;
        }

        public override ComponentContainer Create(Vector3 position)
        {
            var componentContainer =  _poolProvider.ObjectPool.Spawn();
            componentContainer.transform.position = position;
            componentContainer.Register(_systemsContainer);
            return componentContainer;
        }
    }
}