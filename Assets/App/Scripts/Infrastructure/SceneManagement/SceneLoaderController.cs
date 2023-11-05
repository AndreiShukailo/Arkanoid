using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement.Config;
using App.Scripts.Infrastructure.SceneManagement.Factory;
using App.Scripts.Infrastructure.SceneManagement.View;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure.SceneManagement
{
    public class SceneLoaderController
    {
        public ScenesConfig ScenesConfig { get; }

        private readonly LoadingCurtainViewFactory _loadingCurtainViewFactory;
        private LoadingCurtainView _loadingCurtainView;

        public SceneLoaderController(ScenesConfig scenesConfig)
        {
            ScenesConfig = scenesConfig;
            _loadingCurtainViewFactory = CreateFactory(scenesConfig);
            _loadingCurtainView = CreateCurtain();
        }

        public async Task ProcessOpenCurrentScene()
        {
            await _loadingCurtainView.ProcessHide();
        }

        public async Task ProcessLoadScene(SceneInfo sceneInfo)
        {
            _loadingCurtainView = CreateCurtain();
            await _loadingCurtainView.ProcessShow();
            await LoadSceneAsync(sceneInfo);
        }

        private async Task LoadSceneAsync(SceneInfo sceneInfo)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(sceneInfo.SceneName);
            while (!asyncLoad.isDone)
                await Task.Yield();
        }

        private LoadingCurtainView CreateCurtain()
        {
            return _loadingCurtainViewFactory.Create();
        }

        private LoadingCurtainViewFactory CreateFactory(ScenesConfig scenesConfig)
        {
            return new LoadingCurtainViewFactory(scenesConfig.PoolSetting);
        }
    }
}