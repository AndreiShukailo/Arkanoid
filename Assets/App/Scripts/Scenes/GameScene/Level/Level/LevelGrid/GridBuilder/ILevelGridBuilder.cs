using System.Threading.Tasks;
using App.Scripts.Libs.TiledParser.Level;

namespace App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder
{
    public interface ILevelGridBuilder
    {
        public Task<Grid> BuildGrid(LevelInfo levelInfo);
    }
}