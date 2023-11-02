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
            var rect = GetCameraRect(levelFieldConfig);

            var orthographicSize = _camera.orthographicSize;
            var topPadding = orthographicSize * 2 * levelFieldConfig.TopPaddingInPercent / 100f;
            var sidePadding = orthographicSize * 2 * _camera.aspect * levelFieldConfig.SidePaddingInPercent / 100f;
            rect.yMax -= topPadding;
            rect.xMin += sidePadding;
            rect.xMax -= sidePadding;
            
            return new FieldInfo(rect);
        }

        private Rect GetCameraRect(LevelFieldConfig levelFieldConfig)
        {
            var orthographicSize = _camera.orthographicSize;
            var cameraHeight = orthographicSize * 2f;
            var cameraWidth = orthographicSize * 2f * _camera.aspect;
            var cameraSize = new Vector3(cameraWidth, cameraHeight);
            var cameraPosition = _camera.transform.position;
            var rect = new Rect(cameraPosition, cameraSize)
            {
                center = cameraPosition
            };
            return rect;
        }
    }
}