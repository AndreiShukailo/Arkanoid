namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.Info
{
    public interface IBlockDestroyPathInfo
    {
        bool IsColor { get; }
        bool IsOneStep { get; }

        int[] X { get; }
        int[] Y { get; }
    }
}