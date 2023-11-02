using System;
using UnityEngine;

namespace App.Scripts.Infrastructure.SceneManagement
{
    [CreateAssetMenu(fileName = "ConfigScenes", menuName = "App/Scenes/Scenes Config")]
    public class ScenesConfig : ScriptableObject
    {
        public SceneInfo GameScene;
        public SceneInfo PackSelectedScene;
        public SceneInfo StartScene;
    }

    [Serializable]
    public class SceneInfo
    {
        public string SceneName;
    }
}