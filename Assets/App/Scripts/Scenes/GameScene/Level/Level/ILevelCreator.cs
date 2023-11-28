using System.Threading.Tasks;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public interface ILevelCreator
    {
        Task<LevelModel> CreateLevel(PackInfo packInfo, LevelController levelController);
    }
}