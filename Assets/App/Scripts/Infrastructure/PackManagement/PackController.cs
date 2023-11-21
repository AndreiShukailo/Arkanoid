using System.Collections.Generic;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;

namespace App.Scripts.Infrastructure.PackManagement
{
    public class PackController
    {
        public PackInfo CurrentPack { get; private set; }
        public PlayerProgress PlayerProgress => _playerProgress;
        public bool IsFirst { get; private set; }

        private readonly SaveLoadService _saveLoadService;
        private readonly PackContainer _packContainer;
        private readonly EnergyController _energyController;
        private readonly PlayerProgress _playerProgress;

        public PackController(SaveLoadService saveLoadService, PackContainer packContainer, EnergyController energyController)
        {
            _packContainer = packContainer;
            _energyController = energyController;
            _saveLoadService = saveLoadService;
            _playerProgress = GetCurrentPlayerProgress();
        }

        public void SetLastPack()
        {
            CurrentPack = _playerProgress.LastPack;
            IsFirst = false;
        }

        public bool SetPack(PackInfo packInfo)
        {
            if (!_energyController.StartLevel()) return false; 
            CurrentPack = packInfo;
            return true;
        }

        public void NextLevel()
        {
            _energyController.VictoryLevel();
            PackInfo currentPack = null;
            if (CurrentPack.LastLevel < GetPack(CurrentPack).LevelsCount)
            {
                CurrentPack.LastLevel++;
            }
            else
            {
                if (CurrentPackIsLast())
                {
                    _playerProgress.CompletedPacks.Add(CurrentPack);
                    if (CurrentPack.PackId < _packContainer.PackCount)
                    {
                        _playerProgress.LastPack = new PackInfo(CurrentPack.PackId + 1, 1);
                        currentPack = _playerProgress.LastPack;
                    }
                }

                CurrentPack.LastLevel = 1;
                CurrentPack = currentPack;
            }

            _saveLoadService.Save(_playerProgress);
        }

        public Pack GetPack(PackInfo packInfo)
        {
            return _packContainer.GetPack(packInfo.PackId);
        }

        public IEnumerable<Pack> GetAllPacks()
        {
            return _packContainer.GetAll();
        }

        private bool CurrentPackIsLast()
        {
            return CurrentPack == _playerProgress.LastPack;
        }

        private PlayerProgress GetCurrentPlayerProgress()
        {
            var pack = _saveLoadService.Load<PlayerProgress>();
            if (pack != null) return pack;
            IsFirst = true;
            pack = new PlayerProgress();

            return pack;
        }
    }
}