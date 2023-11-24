using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Libs.Components
{
    public class DeathSystem : ComponentSystem<DeathComponent>
    {
        private readonly LevelController _levelController;
        private readonly SpeedComplicationSystem _speedComplicationSystem;

        public DeathSystem(LevelController levelController)
        {
            _levelController = levelController;
        }

        public override void OnUpdate(DeathComponent component)
        {
            base.OnUpdate(component);
            var cellComponent = component.ComponentContainer.Get<CellComponent>();
            component.ComponentContainer.Remove();
            if (cellComponent == null) return;
            _levelController.LevelModel.LevelGrid.Cells[cellComponent.Position.x][cellComponent.Position.y]
                .RemoveCellComponent();
            _levelController.LevelModel.LevelGrid.RemoveBlock(cellComponent);
            _levelController.UpdateLevelProgress();
        }
    }
}