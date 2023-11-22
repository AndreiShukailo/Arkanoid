namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.Info
{
    public class HorizontalDestroyPathInfo : IBlockDestroyPathInfo
    {
        public bool IsColor => false;
        public bool IsOneStep => false;
        public int[] X => new[] { 0, 0};
        public int[] Y => new[] { -1, 1};
    }
}