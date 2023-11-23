namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.Info
{
    public interface IBlockDestroyPathInfo
    {
        bool IsOneStep { get; }

        int[] X { get; }
        int[] Y { get; }
    }
}