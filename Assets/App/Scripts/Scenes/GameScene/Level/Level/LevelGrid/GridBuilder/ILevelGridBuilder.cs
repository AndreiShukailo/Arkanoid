using App.Scripts.Libs.TiledParser.Level;

namespace App.Scripts.Scenes.Game.Level.Level.LevelGrid.GridBuilder
{
    public interface ILevelGridBuilder
    {
        public Grid BuildGrid(LevelInfo levelInfo);
    }
}