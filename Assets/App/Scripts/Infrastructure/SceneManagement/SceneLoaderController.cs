using System.Threading.Tasks;
using App.Scripts.Infrastructure.SceneManagement.Config;
using App.Scripts.Infrastructure.SceneManagement.Factory;
using App.Scripts.Infrastructure.SceneManagement.View;
using App.Scripts.Infrastructure.States;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure.SceneManagement
{
    public class SceneLoaderController
    {
        public ScenesConfig ScenesConfig { get; }
        
        private readonly CommandChangeState _commandChangeState;
        private readonly LoadingCurtainViewFactory _loadingCurtainViewFactory;
        
        private LoadingCurtainView _loadingCurtainView;
        private SceneInfo _nextScene;

        public SceneLoaderController(ScenesConfig scenesConfig, CommandChangeState commandChangeState)
        {
            _commandChangeState = commandChangeState;
            ScenesConfig = scenesConfig;
            _loadingCurtainViewFactory = CreateFactory(scenesConfig);
            _loadingCurtainView = CreateCurtain();
        }

        public async Task ProcessOpenCurrentScene()
        {
            await _loadingCurtainView.ProcessHide();
        }

        public async Task ProcessLoadScene()
        {
            _loadingCurtainView = CreateCurtain();
            await _loadingCurtainView.ProcessShow();
            await LoadSceneAsync(_nextScene);
            _nextScene = null;
        }

        public void SetNextScene(SceneInfo sceneInfo)
        {
            _nextScene = sceneInfo;
            _commandChangeState.ChangeState<LoadSceneState>();
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