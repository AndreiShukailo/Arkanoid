using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.Field
{
    public class FieldInfo
    {
        public readonly Rect CameraBorders;
        public readonly Rect FieldRect;

        public FieldInfo(Rect fieldRect, Rect cameraBorders)
        {
            FieldRect = fieldRect;
            CameraBorders = cameraBorders;
        }
    }
}