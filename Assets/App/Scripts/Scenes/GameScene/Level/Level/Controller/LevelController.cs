using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Model;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Platform.Model;

namespace App.Scripts.Scenes.GameScene.Level.Level.Controller
{
    public class LevelController
    {
        public PlatformModel PlatformModel { get; private set; }
        public LevelModel LevelModel { get; private set; }
        public BallContainer BallContainer { get; private set; }

        private readonly HealthController _healthController;
        private readonly CommandChangeState _commandChangeState;
        private readonly PopUpController _popUpController;

        public LevelController(BallContainer ballContainer, HealthController healthController, CommandChangeState commandChangeState, PopUpController popUpController)
        {
            _healthController = healthController;
            _commandChangeState = commandChangeState;
            _popUpController = popUpController;
            BallContainer = ballContainer;
        }

        public void SetupLevel(LevelModel levelModel)
        {
            LevelModel = levelModel;
        }

        public void SetupPlatform(PlatformModel platformModel, BallModel ballModel)
        {
            PlatformModel = platformModel;
            BallContainer.AddBall(ballModel);
        }

        public void Loose()
        {
            _healthController.RemoveHealth();

            if (_healthController.Health > 0)
            {
                _commandChangeState.ChangeState<ReloadPlatformState>();
                return;
            }
            
            _popUpController.ShowPopup("Lose");
        }
    }
}