using App.Scripts.Libs.Factory;

namespace App.Scripts.Libs.Pool
{
    public abstract class PoolFactory<TView, TContext> : IFactory<TView, TContext> where TView : SpawnableItemMono
    {
        protected PoolProviderMono<TView> _poolProvider;

        protected PoolFactory(PoolSetting<TView> poolSetting)
        {
            _poolProvider = new PoolProviderMono<TView>(poolSetting);
        }

        public abstract TView Create(TContext value);
    }
    
    public abstract class PoolFactory<TView> : IFactory<TView> where TView : SpawnableItemMono
    {
        protected PoolProviderMono<TView> _poolProvider;

        protected PoolFactory(PoolSetting<TView> poolSetting)
        {
            _poolProvider = new PoolProviderMono<TView>(poolSetting);
        }

        public abstract TView Create();
    }
}