using App.Scripts.Libs.TiledParser;

namespace App.Scripts.Scenes.Game.Level.LevelGrid
{
    public interface ILevelGridBuilder
    {
        public Grid BuildGrid(LevelInfo levelInfo);
    }
}