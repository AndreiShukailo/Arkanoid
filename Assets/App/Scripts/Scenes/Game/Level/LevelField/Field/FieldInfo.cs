using UnityEngine;

namespace App.Scripts.Scenes.Game.Level.LevelField
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