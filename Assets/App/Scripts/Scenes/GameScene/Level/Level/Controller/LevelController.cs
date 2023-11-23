using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Level.PackInfoFeature;

namespace App.Scripts.Scenes.GameScene.Level.Level.Controller
{
    public class LevelController
    {
        public LevelModel LevelModel { get; private set; }

        public readonly BallContainer BallContainer;
        private readonly HealthController _healthController;
        private readonly CommandChangeState _commandChangeState;
        private readonly LevelProgressInfoController _levelProgressInfoController;
        private readonly SpeedComplicationSystem _speedComplicationSystem;

        private ComponentContainer _platform;
        private int _startBlocksCount;

        public LevelController(BallContainer ballContainer, HealthController healthController,
            CommandChangeState commandChangeState, LevelProgressInfoController levelProgressInfoController,
            SpeedComplicationSystem speedComplicationSystem)
        {
            _healthController = healthController;
            _commandChangeState = commandChangeState;
            _levelProgressInfoController = levelProgressInfoController;
            _speedComplicationSystem = speedComplicationSystem;
            BallContainer = ballContainer;
        }

        public void SetupLevel(LevelModel levelModel)
        {
            LevelModel = levelModel;
            _startBlocksCount = LevelModel.LevelGrid.BlockCount;
            _levelProgressInfoController.UpdatePackInfo();
            UpdateLevelProgress();
            _healthController.ReloadHealth();
        }

        public void SetupPlatform(ComponentContainer platform, ComponentContainer ball)
        {
            _platform = platform;
            BallContainer.AddBall(ball);
        }

        public void UpdateLevelProgress()
        {
            var levelProgress = 1f - (float)LevelModel.LevelGrid.BlockCount / _startBlocksCount;
            _levelProgressInfoController.UpdateLevelProgress(levelProgress);
            _speedComplicationSystem.Complicate(levelProgress);
            if (levelProgress < 1) return;
            _commandChangeState.ChangeState<VictoryState>();
        }

        public void Lose()
        {
            _healthController.RemoveHealth();

            if (_healthController.Health > 0)
            {
                _commandChangeState.ChangeState<ReloadPlatformState>();
                return;
            }

            _commandChangeState.ChangeState<LoseState>();
        }

        public async Task CleanupLevel()
        {
            var cells = LevelModel.LevelGrid.Cells;
            for (int i = 0; i < cells.Length; i++)
            for (int j = 0; j < cells[i].Length; j++)
            {
                if (cells[i][j].CellComponent == null) continue;
                cells[i][j].CellComponent.ComponentContainer.Remove();
                await Task.Yield();
            }

            LevelModel = null;
        }

        public void CleanupPlatform()
        {
            BallContainer.Cleanup();
            _platform.Remove();
        }
    }
}