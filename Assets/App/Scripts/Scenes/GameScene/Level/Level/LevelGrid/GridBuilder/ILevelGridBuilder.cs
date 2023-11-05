using App.Scripts.Libs.TiledParser.Level;

namespace App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder
{
    public interface ILevelGridBuilder
    {
        public Grid BuildGrid(LevelInfo levelInfo);
    }
}