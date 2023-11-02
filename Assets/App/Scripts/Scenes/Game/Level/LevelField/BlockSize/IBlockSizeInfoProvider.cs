namespace App.Scripts.Scenes.Game.Level.LevelField.Config
{
    public interface IBlockSizeInfoProvider
    {
        public BlockSizeInfo CreateBlockSizeInfo(LevelFieldConfig levelFieldConfig,int columCount);
    }
}