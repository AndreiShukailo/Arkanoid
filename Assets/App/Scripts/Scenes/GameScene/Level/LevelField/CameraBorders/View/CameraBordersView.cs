using App.Scripts.Infrastructure.Collider;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.LevelField
{
    public class CameraBordersView : MonoBehaviour, ICollidedItem
    {
        public EdgeCollider2D CameraCollider => _cameraCollider;
        
        [SerializeField] private EdgeCollider2D _cameraCollider;

        private ICollidedModel _collidedModel;

        public void Construct()
        {
            
        }

        public void AddModel(ICollidedModel collidedModel)
        {
            _collidedModel = collidedModel;
        }

        public void OnCollide()
        {
            _collidedModel.OnCollide();
        }
    }
}