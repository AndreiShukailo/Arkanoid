using App.Scripts.Infrastructure.Collider;
using App.Scripts.Scenes.GameScene.Level.LevelField.CameraBorders.View;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.CameraBorders.Model
{
    public class CameraBordersModel : ICollidedModel
    {
        private readonly CameraBordersView _cameraBordersView;

        public CameraBordersModel(CameraBordersView cameraBordersView)
        {
            _cameraBordersView = cameraBordersView;
            _cameraBordersView.AddModel(this);
        }

        public void OnCollide()
        {
        }

        public void CreateCollider(Vector2 startPoint, Vector2 endPoint)
        {
            var cameraCollider = _cameraBordersView.CameraCollider;
            
            cameraCollider.points = new[]
            {
                startPoint,
                endPoint
            };
        }
    }
}