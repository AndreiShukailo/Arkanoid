using App.Scripts.Infrastructure.SaveLoad;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public interface ILevelCreator
    {
        LevelModel CreateLevel(PackInfo packInfo);
    }
}