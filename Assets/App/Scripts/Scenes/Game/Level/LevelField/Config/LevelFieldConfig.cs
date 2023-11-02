using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Scenes.Game.Level.LevelField.Config
{
    [CreateAssetMenu(fileName = "LevelFieldConfig", menuName = "App/Level/Level Field Config")]
    public class LevelFieldConfig : ScriptableObject
    {
        [Range(0f, 100f)] public float TopPaddingInPercent = 10f;
        [Range(0f, 100f)] public float SidePaddingInPercent = 0.87f;
        public float BlockSpacing = 0.02f;
        public float BlockHeight = 0.5f;
    }
}