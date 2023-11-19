using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using App.Scripts.Scenes.GameScene.Platform.Config;
using App.Scripts.Scenes.GameScene.Platform.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Platform
{
    public class PlatformCreator : IPlatformCreator
    {
        private readonly PlatformConfig _platformConfig;
        private readonly FieldInfo _fieldInfo;
        private readonly PlatformFactory _factory;

        public PlatformCreator(PlatformConfig platformConfig, FieldInfo fieldInfo, SystemsContainer systemsContainer)
        {
            _platformConfig = platformConfig;
            _fieldInfo = fieldInfo;
            _factory = new PlatformFactory(_platformConfig.PlatformPoolSetting, systemsContainer);
        }

        public ComponentContainer CreatePlatform()
        {
            var platformStartPosition =
                new Vector2(0, _fieldInfo.CameraBorders.yMin + _platformConfig.PlatformOffsetBottom);
            var spawnContext = new PlatformSpawnContext(platformStartPosition);

            return _factory.Create(spawnContext);
        }
    }
}