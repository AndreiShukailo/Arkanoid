using System;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.Field
{
    [Serializable]
    public class CameraBordersContainer
    {
        public CameraBordersView[] CameraBordersViews;

        public void Register(FieldInfo fieldInfo)
        {
            var corners = GetRectCorners(fieldInfo.CameraBorders);
            for (int i = 0; i < CameraBordersViews.Length; i++)
            {
                var cameraBorderModel = new CameraBordersModel(CameraBordersViews[i]);
                cameraBorderModel.CreateCollider(corners[i][0], corners[i][1]);
            }
        }

        private Vector2[][] GetRectCorners(Rect rect)
        {
            return new[]
            {
                new[]
                {
                    new Vector2(rect.xMin, rect.yMin),
                    new Vector2(rect.xMin, rect.yMax)
                },
                new[]
                {
                    new Vector2(rect.xMin, rect.yMax),
                    new Vector2(rect.xMax, rect.yMax)
                },
                new[]
                {
                    new Vector2(rect.xMax, rect.yMax),
                    new Vector2(rect.xMax, rect.yMin),
                },
                new[]
                {
                    new Vector2(rect.xMax, rect.yMin),
                    new Vector2(rect.xMin, rect.yMin)
                }
            };
        }
    }
}