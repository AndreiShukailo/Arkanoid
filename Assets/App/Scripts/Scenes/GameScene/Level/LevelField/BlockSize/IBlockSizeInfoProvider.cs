namespace App.Scripts.Scenes.GameScene.Level.LevelField.BlockSize
{
    public interface IBlockSizeInfoProvider
    {
        public BlockSizeInfo CreateBlockSizeInfo(int columCount);
    }
}