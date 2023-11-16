using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using App.Scripts.Scenes.GameScene.Platform.Config;
using App.Scripts.Scenes.GameScene.Platform.Factory;
using App.Scripts.Scenes.GameScene.Platform.Model;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public class PlatformCreator : IPlatformCreator
    {
        private readonly PlatformConfig _platformConfig;
        private readonly FieldInfo _fieldInfo;
        private readonly PlatformFactory _factory;

        public PlatformCreator(PlatformConfig platformConfig, FieldInfo fieldInfo, InputSystem inputSystem)
        {
            _platformConfig = platformConfig;
            _fieldInfo = fieldInfo;
            _factory = new PlatformFactory(_platformConfig.PlatformPoolSetting, inputSystem);
        }

        public PlatformModel CreatePlatform()
        {
            var platformStartPosition =
                new Vector2(0, _fieldInfo.CameraBorders.yMin + _platformConfig.PlatformOffsetBottom);
            var spawnContext = new PlatformSpawnContext(platformStartPosition, _platformConfig.StartSpeed);

            return _factory.Create(spawnContext);
        }
    }
}