using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Infrastructure.EnergyFeature
{
    public class EnergyTimerSystem
    {
        private readonly EnergyController _energyController;
        private readonly EnergyViewController _energyViewController;
        private int _energyTimer;

        public EnergyTimerSystem(EnergyController energyController, EnergyViewController energyViewController)
        {
            _energyController = energyController;
            _energyViewController = energyViewController;
        }

        public void StartTimer()
        {
            EnergyTimer().Forget();
        }

        private async Task EnergyTimer()
        {
            while (true)
            {
                await Task.Delay(1000);
                _energyController.SetTimeLeft(_energyController.TimeLeft - 1);
                if (_energyController.TimeLeft <= 0)
                    UpdateEnergy();
                else
                    _energyViewController.UpdateTimer(_energyController.TimeLeft);
            }
        }

        private void UpdateEnergy()
        {
            _energyController.UpdateEnergy();
            _energyViewController.UpdateEnergy().Forget();
        }
    }
}