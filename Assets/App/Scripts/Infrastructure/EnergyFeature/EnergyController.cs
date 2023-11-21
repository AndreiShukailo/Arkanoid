using System;
using System.Globalization;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;

namespace App.Scripts.Infrastructure.EnergyFeature
{
    public class EnergyController
    {
        public int CurrentEnergy => _playerEnergy.Energy;
        public int MaxEnergy => _energyConfig.MaxEnergy;

        private readonly SaveLoadService _saveLoadService;
        private readonly EnergyConfig _energyConfig;
        private readonly PlayerEnergy _playerEnergy;

        public EnergyController(SaveLoadService saveLoadService, EnergyConfig energyConfig)
        {
            _saveLoadService = saveLoadService;
            _energyConfig = energyConfig;
            _playerEnergy = GetPlayerEnergy();
            UpdateEnergyByTime();
        }

        public bool StartLevel()
        {
            if (_playerEnergy.Energy < _energyConfig.RestartLevelCoast) return false;
            _playerEnergy.Energy -= _energyConfig.RestartLevelCoast;
            SaveEnergy();
            return true;
        }

        public void VictoryLevel()
        {
            _playerEnergy.Energy += _energyConfig.VictoryLevelCoast;
            SaveEnergy();
        }

        public void UpdateEnergy()
        {
            UpdateEnergyByTime();
            SaveEnergy();
        }

        private void UpdateEnergyByTime()
        {
            if (_playerEnergy.Energy >= MaxEnergy)
            {
                UpdateEnergyTime();
                return;
            }
            var minutes = GetSpendedTimeInMinutes();
            var addEnergy = minutes / _energyConfig.TimeToRecoverInMinutes;
            if (addEnergy == 0) return;
            UpdateEnergyTime();
            _playerEnergy.Energy += addEnergy;
            _playerEnergy.Energy = Math.Clamp(_playerEnergy.Energy, 0, MaxEnergy);
        }

        private int GetSpendedTimeInMinutes()
        {
            var savedTime = DateTime.Parse(_playerEnergy.LastTime);
            var currentTime = DateTime.UtcNow;
            var timeDifference = currentTime.Subtract(savedTime);
            var minutes = timeDifference.Minutes;
            return minutes;
        }

        private void UpdateEnergyTime()
        {
            _playerEnergy.LastTime = DateTime.UtcNow.ToString(CultureInfo.CurrentCulture);
        }

        private void SaveEnergy()
        {
            _saveLoadService.Save(_playerEnergy);
        }

        private PlayerEnergy GetPlayerEnergy()
        {
            return _saveLoadService.Load<PlayerEnergy>() ?? new PlayerEnergy(_energyConfig.MaxEnergy, DateTime.UtcNow);
        }
    }
}