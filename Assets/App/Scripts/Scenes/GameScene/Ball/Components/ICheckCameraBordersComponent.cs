using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public interface ICheckCameraBordersComponent
    {
        Rect ItemRect { get; }
        void OnBordersCollide(Vector2 normal);
        void OnCameraInvisible();
    }
}