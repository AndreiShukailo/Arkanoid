using App.Scripts.Scenes.Game.Level.LevelField.Config;

namespace App.Scripts.Scenes.Game.Level.LevelField.BlockSize
{
    public interface IBlockSizeInfoProvider
    {
        public BlockSizeInfo CreateBlockSizeInfo(LevelFieldConfig levelFieldConfig,int columCount);
    }
}