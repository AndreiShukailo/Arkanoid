using App.Scripts.Scenes.Game.Level.LevelField.Config;
using App.Scripts.Scenes.Game.Level.LevelField.Field;

namespace App.Scripts.Scenes.Game.Level.LevelField.BlockSize
{
    class BlockSizeInfoProvider : IBlockSizeInfoProvider
    {
        private readonly FieldInfo _fieldInfo;

        public BlockSizeInfoProvider(FieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
        }

        public BlockSizeInfo CreateBlockSizeInfo(LevelFieldConfig levelFieldConfig, int columCount)
        {
            var spacing = levelFieldConfig.BlockSpacing;
            var width = (_fieldInfo.FieldRect.width - (columCount + 1) * spacing) / columCount;
            var height = width * levelFieldConfig.BlockAspect;

            return new BlockSizeInfo(width, height, spacing);
        }
    }
}