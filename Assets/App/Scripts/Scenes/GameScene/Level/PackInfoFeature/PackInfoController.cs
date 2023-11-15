using System;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.PackInfoFeature
{
    public class PackInfoController
    {
        public Action OnUpdatePackInfo;
        public Pack CurrentPack { get; private set; }
        public PackInfo CurrentPackInfo { get; private set; }
        
        private readonly LevelController _levelController;
        private readonly PackController _packController;

        public PackInfoController(PackController packController)
        {
            _packController = packController;
        }

        public void UpdatePackInfo()
        {
            CurrentPackInfo = _packController.CurrentPack;
            CurrentPack = _packController.GetPack(CurrentPackInfo.PackId);
            
            OnUpdatePackInfo?.Invoke();
        }
    }
}