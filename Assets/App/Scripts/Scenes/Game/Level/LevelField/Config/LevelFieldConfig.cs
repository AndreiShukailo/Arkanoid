using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Scenes.Game.Level.LevelField.Config
{
    [CreateAssetMenu(fileName = "LevelFieldConfig", menuName = "App/Level/Level Field Config")]
    public class LevelFieldConfig : ScriptableObject
    {
        public float PixelsPerUnit = 100f;
        [Range(0, 100)] public int TopPaddingInPercent = 10;
        public int SidePadding = 10;
        public int BlockSpacing = 2;
        public int BlockHeight = 50;
    }
}