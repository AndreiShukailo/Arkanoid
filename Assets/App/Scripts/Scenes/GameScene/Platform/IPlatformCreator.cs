using App.Scripts.Scenes.GameScene.Platform.Model;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public interface IPlatformCreator
    {
        PlatformModel CreatePlatform();
    }
}