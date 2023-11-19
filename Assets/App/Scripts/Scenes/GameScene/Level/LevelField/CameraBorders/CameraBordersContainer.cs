using System;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.CameraBorders
{
    [Serializable]
    public class CameraBordersContainer
    {
        public ComponentContainer[] CameraBorders;

        public void Register(FieldInfo fieldInfo, CameraBordersFactory cameraBordersFactory)
        {
            var corners = GetRectCorners(fieldInfo.CameraBorders);
            for (var i = 0; i < CameraBorders.Length; i++)
            {
                var componentContainer = cameraBordersFactory.Create(CameraBorders[i]);
                componentContainer.Get<BorderViewComponent>().Construct(corners[i][0], corners[i][1]);
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