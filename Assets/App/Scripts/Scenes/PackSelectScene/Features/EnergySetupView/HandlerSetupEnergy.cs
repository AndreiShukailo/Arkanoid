using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Scenes.PackSelectScene.Features
{
    public class HandlerSetupEnergy : IHandlerSetupScene
    {
        private readonly EnergyViewController _energyViewController;
        private readonly EnergyContainer _energyContainer;

        public HandlerSetupEnergy(EnergyViewController energyViewController, EnergyContainer energyContainer)
        {
            _energyViewController = energyViewController;
            _energyContainer = energyContainer;
        }

        public Task Process()
        {
            _energyViewController.CreateEnergy(_energyContainer.transform);
            _energyViewController.UpdateEnergy().Forget();
            return Task.CompletedTask;
        }
    }
}