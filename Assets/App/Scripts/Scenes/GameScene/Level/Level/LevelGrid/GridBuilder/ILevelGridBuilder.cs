using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder
{
    public interface ILevelGridBuilder
    {
        public Grid BuildGrid(LevelInfo levelInfo, LevelController levelController);
    }
}