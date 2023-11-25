using App.Scripts.Libs.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public interface IBallCreator
    {
        ComponentContainer CreateBall(ComponentContainer platform);
        ComponentContainer CreateBall(Vector2 blockPosition);
    }
}