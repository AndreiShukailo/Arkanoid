using System;
using System.Globalization;
using App.Scripts.Infrastructure.EnergyFeature.Config;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;

namespace App.Scripts.Infrastructure.EnergyFeature
{
    public class EnergyController
    {
        public int TimeLeft { get; private set; }
        public int CurrentEnergy => _playerEnergy.Energy;
        public int MaxEnergy => _energyConfig.MaxEnergy;
        public int TimeToUpdate => _energyConfig.TimeToRecoverInMinutes;

        private readonly SaveLoadService _saveLoadService;
        private readonly EnergyConfig _energyConfig;
        private readonly PlayerEnergy _playerEnergy;

        public EnergyController(SaveLoadService saveLoadService, EnergyConfig energyConfig)
        {
            _saveLoadService = saveLoadService;
            _energyConfig = energyConfig;
            _playerEnergy = GetPlayerEnergy();
            UpdateEnergy();
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

        public void SetTimeLeft(int timeLeft)
        {
            TimeLeft = timeLeft;
        }

        private void UpdateEnergyByTime()
        {
            var seconds = GetSpendedTimeInSeconds();
            TimeLeft = TimeToUpdate * 60 - seconds  % (_energyConfig.TimeToRecoverInMinutes * 60);
            var addEnergy = seconds / (_energyConfig.TimeToRecoverInMinutes * 60);
            if (addEnergy == 0) return;
            UpdateEnergyTime();
            if (_playerEnergy.Energy >= MaxEnergy) return;
            _playerEnergy.Energy += addEnergy;
            _playerEnergy.Energy = Math.Clamp(_playerEnergy.Energy, 0, MaxEnergy);
        }
        
        private int GetSpendedTimeInSeconds()
        {
            var savedTime = DateTime.Parse(_playerEnergy.LastTime);
            var currentTime = DateTime.UtcNow;
            var timeDifference = currentTime.Subtract(savedTime);
            var seconds = timeDifference.TotalSeconds;
            return (int)seconds;
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