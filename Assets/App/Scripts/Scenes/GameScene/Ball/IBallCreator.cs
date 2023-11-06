using App.Scripts.Infrastructure.Component;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public interface IBallCreator
    {
        ComponentsContainer CreateBall();
    }
}