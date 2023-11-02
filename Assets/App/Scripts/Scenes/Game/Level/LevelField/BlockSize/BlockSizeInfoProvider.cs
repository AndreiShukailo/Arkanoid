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
            var spacing = levelFieldConfig.BlockSpacing ;
            var height = levelFieldConfig.BlockHeight;
            var width = (_fieldInfo.FieldRect.width - (columCount + 1) * spacing) / columCount;

            return new BlockSizeInfo(width, height, spacing);
        }
    }
}