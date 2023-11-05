using App.Scripts.Infrastructure.SceneManagement.Pool;
using App.Scripts.Infrastructure.SceneManagement.View;
using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Pool;

namespace App.Scripts.Infrastructure.SceneManagement.Factory
{
    public class LoadingCurtainViewFactory : IFactory<LoadingCurtainView>
    {
        private readonly PoolProviderMono<LoadingCurtainView> _poolProvider;

        public LoadingCurtainViewFactory(LoadingCurtainPoolSetting loadingCurtainPoolSetting)
        {
            _poolProvider = new PoolProviderMono<LoadingCurtainView>(loadingCurtainPoolSetting);
        }

        public LoadingCurtainView Create()
        {
            return _poolProvider.ObjectPool.Spawn();
        }
    }
}