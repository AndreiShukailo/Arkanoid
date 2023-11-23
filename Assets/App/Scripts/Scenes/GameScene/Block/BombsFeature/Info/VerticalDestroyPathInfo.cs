namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.Info
{
    public class VerticalDestroyPathInfo : IBlockDestroyPathInfo
    {
        public bool IsOneStep => false;
        public int[] X => new[] { -1, 1};
        public int[] Y => new[] { 0, 0};
    }
}