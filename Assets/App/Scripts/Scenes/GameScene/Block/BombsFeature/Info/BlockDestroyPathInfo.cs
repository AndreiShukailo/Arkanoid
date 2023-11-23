namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.Info
{
    public class BlockDestroyPathInfo : IBlockDestroyPathInfo
    {
        public bool IsOneStep => true;
        public int[] X => new[] { -1, -1, -1, 0, 1, 1, 1, 0 };
        public int[] Y => new[] { -1, 0, 1, 1, 1, 0, -1, -1 };
    }
}