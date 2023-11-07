using App.Scripts.Scenes.GameScene.Platform.View;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public class PlatformModel
    {
        private PlatformView _platformView;
        private readonly float _startSpeed;

        public PlatformModel(PlatformView platformView, float startSpeed)
        {
            _platformView = platformView;
            _startSpeed = startSpeed;
        }
    }
}