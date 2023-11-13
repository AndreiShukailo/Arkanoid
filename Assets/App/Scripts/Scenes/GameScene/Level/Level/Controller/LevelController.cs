using App.Scripts.Infrastructure.States;
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
        
        private readonly CommandChangeState _commandChangeState;


        public LevelController(BallContainer ballContainer, CommandChangeState commandChangeState)
        {
            _commandChangeState = commandChangeState;
            BallContainer = ballContainer;
        }

        public void SetupLevel(LevelModel levelModel, PlatformModel platformModel, BallModel ballModel)
        {
            LevelModel= levelModel;
            PlatformModel = platformModel;
            BallContainer.AddBall(ballModel);
        }

        public void Loose()
        {
            _commandChangeState.ChangeState<ReloadLevelState>();
        }
    }
}