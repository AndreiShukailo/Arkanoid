using System.Collections.Generic;
using App.Scripts.Infrastructure.LevelsManagement;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;

namespace App.Scripts.Infrastructure.PackManagement
{
    public class PackController
    {
        public PackInfo CurrentPack { get; private set; }
        public PlayerProgress PlayerProgress => _playerProgress;

        private readonly SaveLoadService _saveLoadService;
        private readonly PackContainer _packContainer;
        private readonly PlayerProgress _playerProgress;

        public PackController(SaveLoadService saveLoadService, PackContainer packContainer)
        {
            _packContainer = packContainer;
            _saveLoadService = saveLoadService;
            _playerProgress = GetCurrentPlayerProgress();
        }

        public void SetLastPack()
        {
            CurrentPack = _playerProgress.LastPack;
        }

        public void SetPack(PackInfo packInfo)
        {
            CurrentPack = packInfo;
        }

        public void NextLevel()
        {
            if (CurrentPack.LastLevel <= GetPack(CurrentPack.PackId).LevelsCount)
            {
                CurrentPack.LastLevel++;
            }
            else if(CurrentPack == _playerProgress.LastPack)
            {
                _playerProgress.CompletedPacks.Add(CurrentPack);
                _playerProgress.LastPack = new PackInfo(CurrentPack.PackId, CurrentPack.LastLevel);
                CurrentPack = _playerProgress.LastPack;
            }
            else
            {
                CurrentPack = null;
            }

            _saveLoadService.Save(_playerProgress);
        }

        public Pack GetPack(int key)
        {
            return _packContainer.GetPack(key);
        }

        public IEnumerable<Pack> GetAllPacks()
        {
            return _packContainer.GetAll();
        }

        private PlayerProgress GetCurrentPlayerProgress()
        {
            return _saveLoadService.Load<PlayerProgress>() ?? new PlayerProgress();
        }
    }
}