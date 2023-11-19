using System;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;

namespace App.Scripts.Scenes.GameScene.Level.PackInfoFeature
{
    public class LevelProgressInfoController
    {
        public event Action OnUpdatePackInfo;
        public event Action OnUpdateLevelProgress;

        public float CurrentLevelProgress { get; private set; }
        public Pack CurrentPack { get; private set; }
        public PackInfo CurrentPackInfo { get; private set; }
        
        private readonly PackController _packController;

        public LevelProgressInfoController(PackController packController)
        {
            _packController = packController;
        }

        public void UpdatePackInfo()
        {
            CurrentPackInfo = _packController.CurrentPack;
            CurrentPack = _packController.GetPack(CurrentPackInfo);
            
            OnUpdatePackInfo?.Invoke();
        }

        public void UpdateLevelProgress(float progress)
        {
            CurrentLevelProgress = progress;
            OnUpdateLevelProgress?.Invoke();
        }
    }
}