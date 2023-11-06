using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public interface IPhysicalComponent
    {
        Vector2 Velocity { get; }
        void Reflect(Vector2 normal);
        Rect GetRectCollider();
    }
}