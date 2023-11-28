using System.Threading.Tasks;
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

        public async Task<LevelModel> CreateLevel(PackInfo packInfo, LevelController levelController)
        {
            var path = _levelPathCreator.CreatePath(packInfo);
            var levelInfo = _levelParser.CreateLevelGrid(path);
            var gridTask = _levelGridBuilder.BuildGrid(levelInfo);
            await gridTask;
            return new LevelModel(gridTask.Result);
        }
    }
}