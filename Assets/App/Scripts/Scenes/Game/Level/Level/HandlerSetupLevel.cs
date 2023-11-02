using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.TiledParser;
using App.Scripts.Scenes.Game.Block.View;
using App.Scripts.Scenes.Game.Level.LevelField;
using App.Scripts.Scenes.Game.Level.LevelField.Config;

namespace App.Scripts.Scenes.Game.Level.LevelGrid
{
    public class HandlerSetupLevel : IHandlerSetupScene
    {
        private readonly TextDataProvider _textDataProvider;
        private readonly BlockView _blockView;
        private readonly FieldInfo _fieldInfo;
        private readonly IBlockCreator _blockCreator;
        private readonly LevelFieldConfig _levelFieldConfig;

        public HandlerSetupLevel(TextDataProvider textDataProvider, BlockView blockView, FieldInfo fieldInfo, IBlockCreator blockCreator, LevelFieldConfig levelFieldConfig)
        {
            _textDataProvider = textDataProvider;
            _blockView = blockView;
            _fieldInfo = fieldInfo;
            _blockCreator = blockCreator;
            _levelFieldConfig = levelFieldConfig;
        }

        public Task Process()
        {
            SetupLevel();
            return Task.CompletedTask;
        }

        private void SetupLevel()
        {
            var tiledMapProvider = new TiledMapProvider(_textDataProvider);
            var levelParser = new LevelParser(tiledMapProvider);
            var levelInfo = levelParser.CreateLevelGrid("Levels/LevelPack0/TestLevel");
            var blockSizeInfo = new BlockSizeInfoProvider(_fieldInfo).CreateBlockSizeInfo(_levelFieldConfig, levelInfo.Width);
            var gridBuilder = new LevelGridBuilder(blockSizeInfo, _fieldInfo, _blockCreator);
            var cells = gridBuilder.BuildGrid(levelInfo);
            var levelModel = new LevelModel(cells);
        }
    }
}