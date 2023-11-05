using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.Field
{
    public class FieldInfo
    {
        public Rect FieldRect;

        public FieldInfo(Rect fieldRect)
        {
            FieldRect = fieldRect;
        }
    }
}