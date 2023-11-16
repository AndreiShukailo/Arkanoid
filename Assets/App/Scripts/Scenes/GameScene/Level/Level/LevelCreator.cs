using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
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

        public LevelModel CreateLevel(PackInfo packInfo, LevelController levelController)
        {
            var path = _levelPathCreator.CreatePath(packInfo);
            var levelInfo = _levelParser.CreateLevelGrid(path);
            return new LevelModel(_levelGridBuilder.BuildGrid(levelInfo, levelController));
        }
    }
}