using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.Field
{
    public class CameraColliderCreator
    {
        private readonly FieldInfo _fieldInfo;
        private readonly EdgeCollider2D _cameraCollider;

        public CameraColliderCreator(FieldInfo fieldInfo, EdgeCollider2D cameraCollider)
        {
            _fieldInfo = fieldInfo;
            _cameraCollider = cameraCollider;
        }

        public void CreateCollider()
        {
            var cameraRect = _fieldInfo.CameraBorders;

            _cameraCollider.points = new[]
            {
                new Vector2(cameraRect.xMin, cameraRect.yMin),
                new Vector2(cameraRect.xMin, cameraRect.yMax),
                new Vector2(cameraRect.xMax, cameraRect.yMax),
                new Vector2(cameraRect.xMax, cameraRect.yMin)
            };
        }
    }
}