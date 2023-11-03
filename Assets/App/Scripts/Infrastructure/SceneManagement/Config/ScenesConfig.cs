using System;
using App.Scripts.Infrastructure.SceneManagement.Pool;
using UnityEngine;

namespace App.Scripts.Infrastructure.SceneManagement.Config
{
    [CreateAssetMenu(fileName = "ConfigScenes", menuName = "App/Scenes/Scenes Config")]
    public class ScenesConfig : ScriptableObject
    {
        public SceneInfo GameScene;
        public SceneInfo PackSelectedScene;
        public SceneInfo StartScene;
        public LoadingCurtainPoolSetting PoolSetting;
    }

    [Serializable]
    public class SceneInfo
    {
        public string SceneName;
    }
}