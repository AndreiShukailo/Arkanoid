using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Platform.Config;
using App.Scripts.Scenes.GameScene.Platform.Factory;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public class PlatformCreator : IPlatformCreator
    {
        private readonly PlatformConfig _platformConfig;
        private readonly InputSystem _inputSystem;

        public PlatformCreator(PlatformConfig platformConfig, InputSystem inputSystem)
        {
            _platformConfig = platformConfig;
            _inputSystem = inputSystem;
        }

        public PlatformModel CreatePlatform()
        {
            var spawnContext = new PlatformSpawnContext(_platformConfig.StartPosition, _platformConfig.StartSpeed);
            var factory = new PlatformFactory(_platformConfig.PlatformPoolSetting, _inputSystem);

            return factory.Create(spawnContext);
        }
    }
}