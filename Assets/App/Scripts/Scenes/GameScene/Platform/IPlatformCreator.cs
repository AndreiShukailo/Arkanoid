using App.Scripts.Libs.Components;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public interface IPlatformCreator
    {
        ComponentContainer CreatePlatform();
    }
}