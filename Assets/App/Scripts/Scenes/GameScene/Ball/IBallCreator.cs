using App.Scripts.Scenes.GameScene.Ball.Model;
using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.Platform.Model;

namespace App.Scripts.Scenes.GameScene.Ball
{
    public interface IBallCreator
    {
        BallModel CreateBall(PlatformModel platformModel);
    }
}