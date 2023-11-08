using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.Config
{
    [CreateAssetMenu(fileName = "LevelFieldConfig", menuName = "App/Level/Level Field Config")]
    public class LevelFieldConfig : ScriptableObject
    {
        [Range(0f, 100f)] public float TopUIPaddingInPercent = 9.59f;
        [Range(0f, 100f)] public float TopPaddingInPercent = 5.124f;
        [Range(0f, 100f)] public float SidePaddingInPercent = 0.87f;
        public float BlockSpacing = 0.02f;
        public float BlockAspect = 0.48f;
    }
}