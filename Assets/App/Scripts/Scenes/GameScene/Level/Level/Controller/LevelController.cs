using System.Threading.Tasks;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.PopUp;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Model;
using App.Scripts.Scenes.GameScene.Block.Model;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Platform.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.Level.Controller
{
    public class LevelController
    {
        public LevelModel LevelModel { get; private set; }
        public readonly BallContainer BallContainer;

        private readonly HealthController _healthController;
        private readonly CommandChangeState _commandChangeState;
        private readonly PopUpController _popUpController;
        
        private PlatformModel _platformModel;
        private int _blocksCount;
        private bool _isCleanup;

        public LevelController(BallContainer ballContainer, HealthController healthController,
            CommandChangeState commandChangeState, PopUpController popUpController)
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
            _platformModel = platformModel;
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

        public void SubscribeOnBlock(BlockModel blockModel)
        {
            blockModel.OnRemove += OnBlockRemove;
            _blocksCount++;
        }

        private void OnBlockRemove(BlockModel blockModel)
        {
            blockModel.OnRemove -= OnBlockRemove;
            blockModel = null;
            _blocksCount--;

            if (_blocksCount > 0 || _isCleanup) return;
            
            
            _commandChangeState.ChangeState<ReloadLevelState>();
            Debug.Log("Victory");
        }

        public async Task CleanupLevel()
        {
            _isCleanup = true;
            var cells = LevelModel.LevelGrid.Cells;
            for (int i = 0; i < cells.Length; i++)
            for (int j = 0; j < cells[i].Length; j++)
            {
                cells[i][j].Block?.Remove();
                await Task.Yield();
            }

            _isCleanup = false;
            LevelModel = null;
        }

        public void CleanupPlatform()
        {
            BallContainer.Cleanup();
            _platformModel.Remove();
        }
    }
}