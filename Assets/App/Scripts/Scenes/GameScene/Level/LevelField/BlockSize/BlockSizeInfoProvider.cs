using App.Scripts.Scenes.GameScene.Level.LevelField.Config;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;

namespace App.Scripts.Scenes.GameScene.Level.LevelField.BlockSize
{
    class BlockSizeInfoProvider : IBlockSizeInfoProvider
    {
        private readonly FieldInfo _fieldInfo;
        private readonly LevelFieldConfig _levelFieldConfig;

        public BlockSizeInfoProvider(FieldInfo fieldInfo, LevelFieldConfig levelFieldConfig)
        {
            _fieldInfo = fieldInfo;
            _levelFieldConfig = levelFieldConfig;
        }

        public BlockSizeInfo CreateBlockSizeInfo(int columCount)
        {
            var spacing = _levelFieldConfig.BlockSpacing;
            var width = (_fieldInfo.FieldRect.width - (columCount + 1) * spacing) / columCount;
            var height = width * _levelFieldConfig.BlockAspect;

            return new BlockSizeInfo(width, height, spacing);
        }
    }
}