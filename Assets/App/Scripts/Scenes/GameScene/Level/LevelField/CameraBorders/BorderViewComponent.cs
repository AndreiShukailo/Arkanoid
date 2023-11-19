using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.CameraBorders
{
    public class BorderViewComponent : Libs.Components.Component
    {
        [SerializeField] private EdgeCollider2D _collider;


        public void Construct(Vector2 startPoint, Vector2 endPoint)
        {
            CreateCollider(startPoint, endPoint);
        }

        private void CreateCollider(Vector2 startPoint, Vector2 endPoint)
        {
            _collider.points = new[]
            {
                startPoint,
                endPoint
            };
        }
    }
}