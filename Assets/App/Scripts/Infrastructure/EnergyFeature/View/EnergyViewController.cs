using System.Threading.Tasks;
using App.Scripts.Infrastructure.EnergyFeature.Factory;
using UnityEngine;

namespace App.Scripts.Infrastructure.EnergyFeature.View
{
    public class EnergyViewController
    {
        private readonly EnergyController _energyController;
        private EnergyViewFactory _energyViewFactory;
        private EnergyView _energyView;
        
        public EnergyViewController(EnergyController energyController, EnergyPollSetting energyPollSetting,
            Canvas energyContainer)
        {
            _energyController = energyController;
            CreateEnergyViewFactory(energyPollSetting, energyContainer);
        }

        public void Remove()
        {
            if(_energyView == null) return;
            _energyView.Remove();
            _energyView = null;
        }

        public async Task UpdateEnergy()
        {
            if(_energyView == null) return;
            UpdateTimer(_energyController.TimeLeft);
            await _energyView.UpdateEnergy(_energyController.CurrentEnergy, _energyController.MaxEnergy);
        }

        public void UpdateTimer(int timeLeft)
        {
            if(_energyView == null) return;
            var isVisible = _energyController.CurrentEnergy < _energyController.MaxEnergy;
            _energyView.UpdateTimer(timeLeft, isVisible);
        }

        public void CreateEnergy(Transform container)
        {
            _energyView = _energyViewFactory.Create();
            _energyView.Construct(_energyController.CurrentEnergy, _energyController.MaxEnergy, container);
        }

        private void CreateEnergyViewFactory(EnergyPollSetting energyPollSetting, Canvas energyContainer)
        {
            energyPollSetting.Container = energyContainer.transform;
            _energyViewFactory = new EnergyViewFactory(energyPollSetting);
        }
    }
}