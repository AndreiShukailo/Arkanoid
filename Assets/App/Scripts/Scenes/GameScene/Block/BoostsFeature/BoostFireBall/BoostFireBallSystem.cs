using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostFireBall
{
    public class BoostFireBallSystem : BoostSystem<BoostFireBallComponent>
    {
        private readonly LevelController _levelController;
        private bool _isFireBall;

        public BoostFireBallSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        protected override void OnUpdateAction()
        {
            _levelController.BallContainer.SetFireBall(_isFireBall);
        }

        protected override void OnActivateAction(BoostFireBallComponent component)
        {
            _isFireBall = true;
            SetTrigger(_isFireBall);
        }

        private void SetTrigger(bool isTrigger)
        {
            foreach (var gridCell in _levelController.LevelModel.LevelGrid.Cells)
            {
                foreach (var cell in gridCell)
                {
                    if (cell.CellComponent == null) continue;
                    cell.CellComponent.ComponentContainer.Get<ControlSizeComponent>().SetTrigger(isTrigger);
                }
            }
        }

        protected override void OnDisableBoostAction()
        {
            _isFireBall = false;
            SetTrigger(_isFireBall);
        }
    }
}