using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Scenes.Game.Level;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    class LevelCreator : ILevelCreator
    {
        private readonly ILevelGridBuilder _levelGridBuilder;
        private readonly ILevelParser _levelParser;
        private readonly ILevelPathCreator _levelPathCreator;

        public LevelCreator(ILevelGridBuilder levelGridBuilder, ILevelParser levelParser, ILevelPathCreator levelPathCreator)
        {
            _levelGridBuilder = levelGridBuilder;
            _levelParser = levelParser;
            _levelPathCreator = levelPathCreator;
        }

        public LevelModel CreateLevel(int packId, int levelId)
        {
            var path = _levelPathCreator.CreatePath(packId, levelId);
            var levelInfo = _levelParser.CreateLevelGrid(path);
            return new LevelModel(_levelGridBuilder.BuildGrid(levelInfo));
        }
    }
}