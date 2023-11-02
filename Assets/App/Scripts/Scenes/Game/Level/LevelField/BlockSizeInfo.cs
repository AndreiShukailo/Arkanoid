namespace App.Scripts.Scenes.Game.Level.LevelField.Config
{
    public class BlockSizeInfo
    {
        public float Width;
        public float Height;
        public float Spacing;

        public BlockSizeInfo(float width, float height, float spacing)
        {
            Width = width;
            Height = height;
            Spacing = spacing;
        }
    }
}