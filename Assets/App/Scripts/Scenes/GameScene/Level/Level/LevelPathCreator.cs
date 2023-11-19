using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Scenes.GameScene.Level.Level.Config;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    class LevelPathCreator : ILevelPathCreator
    {
        private readonly LevelsConfig _levelsConfig;
        private readonly PackController _packController;

        public LevelPathCreator(LevelsConfig levelsConfig, PackController packController)
        {
            _levelsConfig = levelsConfig;
            _packController = packController;
        }

        public string CreatePath(PackInfo packInfo)
        {
            return $"{_levelsConfig.LevelsPath}/{_packController.GetPack(packInfo).Key}/{packInfo.LastLevel}";
        }
    }
}