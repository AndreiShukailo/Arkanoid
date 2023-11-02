using App.Scripts.Scenes.Game.Level.LevelField.Config;
using UnityEngine;

namespace App.Scripts.Scenes.Game.Level.LevelField
{
    class FieldProvider : IFieldProvider
    {
        private readonly Camera _camera;

        public FieldProvider(Camera camera)
        {
            _camera = camera;
        }

        public FieldInfo CreateField(LevelFieldConfig levelFieldConfig)
        {
            var sidePadding = levelFieldConfig.SidePadding / levelFieldConfig.PixelsPerUnit;
            var rect = _camera.rect;
            var size = _camera.aspect * 2 * levelFieldConfig.TopPaddingInPercent / 100f;
            rect.yMax = rect.yMin + size;
            rect.xMin += sidePadding;
            rect.xMax -= sidePadding;
            
            return new FieldInfo(rect);
        }
    }
}