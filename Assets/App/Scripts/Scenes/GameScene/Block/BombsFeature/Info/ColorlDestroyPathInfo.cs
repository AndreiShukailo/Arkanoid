namespace App.Scripts.Scenes.GameScene.Block.BombsFeature.Info
{
    public class ColorDestroyPathInfo : IBlockDestroyPathInfo
    {
        public bool IsColor => true;
        public bool IsOneStep => false;
        public int[] X => new[] { -1, 1, 0, 0};
        public int[] Y => new[] { 0, 0, -1, 1};
    }
}