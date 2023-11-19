using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.SaveLoad;
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
            return _saveLoadService.Load<PlayerProgress>() ?? new PlayerProgress();
        }
    }
}