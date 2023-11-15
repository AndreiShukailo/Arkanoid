using App.Scripts.Infrastructure.SaveLoad;

namespace App.Scripts.Scenes.GameScene.Level.Level
{
    public interface ILevelPathCreator
    {
        string CreatePath(PackInfo packInfo);
    }
}