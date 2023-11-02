namespace App.Scripts.Scenes.Game.Level.LevelField.Config
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
            var spacing = levelFieldConfig.BlockSpacing / levelFieldConfig.PixelsPerUnit;
            var height = levelFieldConfig.BlockHeight / levelFieldConfig.PixelsPerUnit;
            var width = (_fieldInfo.FieldRect.width / columCount) - ((columCount + 1) * spacing);

            return new BlockSizeInfo(width, height, spacing);
        }
    }
}