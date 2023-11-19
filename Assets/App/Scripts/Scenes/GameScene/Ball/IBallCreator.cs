using App.Scripts.Libs.Components;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public interface IBallCreator
    {
        ComponentContainer CreateBall(ComponentContainer platform);
    }
}