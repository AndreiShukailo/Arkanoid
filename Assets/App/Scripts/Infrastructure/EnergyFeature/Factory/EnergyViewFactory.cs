using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Libs.Pool;

namespace App.Scripts.Infrastructure.EnergyFeature.Factory
{
    public class EnergyViewFactory : PoolFactory<EnergyView>
    {
        public EnergyViewFactory(PoolSetting<EnergyView> poolSetting) : base(poolSetting)
        {
        }

        public override EnergyView Create()
        {
            var energyView = _poolProvider.ObjectPool.Spawn();
            return energyView;
        }
    }
}