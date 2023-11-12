using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Model;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.Platform.Model;

namespace App.Scripts.Scenes.GameScene.Level.Level.Controller
{
    public class LevelController
    {
        public PlatformModel PlatformModel { get; private set; }
        public LevelModel LevelModel { get; private set; }
        public BallContainer BallContainer { get; private set; }
        private readonly GameStateMachine _gameStateMachine;

        public LevelController(BallContainer ballContainer, GameStateMachine gameStateMachine)
        {
            BallContainer = ballContainer;
            _gameStateMachine = gameStateMachine;
        }

        public void SetupLevel(LevelModel levelModel, PlatformModel platformModel, BallModel ballModel)
        {
            LevelModel= levelModel;
            PlatformModel = platformModel;
            BallContainer.AddBall(ballModel);
        }

        public void Loose()
        {
            _gameStateMachine.ChangeState<ReloadLevelState>();
        }
    }
}