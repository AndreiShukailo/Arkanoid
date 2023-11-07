using App.Scripts.Scenes.GameScene.Ball.Model;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public interface IBallCreator
    {
        BallModel CreateBall();
    }
}