using App.Scripts.Scenes.GameScene.Level.Level.Config;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    class LevelPathCreator : ILevelPathCreator
    {
        private readonly LevelsConfig _levelsConfig;

        public LevelPathCreator(LevelsConfig levelsConfig)
        {
            _levelsConfig = levelsConfig;
        }

        public string CreatePath(int packId, int levelId)
        {
            return $"{_levelsConfig.LevelsPath}/{_levelsConfig.PackName}{packId}/{_levelsConfig.LevelName}{levelId}";
        }
    }
}