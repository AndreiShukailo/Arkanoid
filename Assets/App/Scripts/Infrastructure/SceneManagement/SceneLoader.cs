using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace App.Scripts.Infrastructure.SceneManagement
{
    public class SceneLoader
    {
        public ScenesConfig ScenesConfig { get; }
        
        private readonly LoadingCurtainViewFactory _curtainFactory;
        private LoadingCurtainView _loadingCurtainView;

        public SceneLoader(ScenesConfig scenesConfig, LoadingCurtainViewFactory loadingCurtainViewFactory)
        {
            ScenesConfig = scenesConfig;
            _curtainFactory = loadingCurtainViewFactory;
            CreateCurtain();
        }

        public async Task ProcessOpenCurrentScene()
        {
            await _loadingCurtainView.ProcessHide();
        }

        public async Task ProcessLoadScene(SceneInfo sceneInfo)
        {
            CreateCurtain();
            await _loadingCurtainView.ProcessShow();
            LoadScene(sceneInfo);
        }

        private void CreateCurtain()
        {
            _loadingCurtainView = _curtainFactory.Create();
        }

        private void LoadScene(SceneInfo sceneInfo)
        {
            SceneManager.LoadScene(sceneInfo.SceneName);
        }
    }
}