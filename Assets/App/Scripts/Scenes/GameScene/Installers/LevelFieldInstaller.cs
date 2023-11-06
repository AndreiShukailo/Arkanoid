using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Block;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder;
using App.Scripts.Scenes.GameScene.Level.LevelField.BlockSize;
using App.Scripts.Scenes.GameScene.Level.LevelField.Config;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class LevelFieldInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EdgeCollider2D _cameraCollider;
        [SerializeField] private LevelFieldConfig _levelFieldConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var fieldInfo = new FieldProvider(_camera)
                .CreateField(_levelFieldConfig);
            var cameraColliderCreator = new CameraColliderCreator(fieldInfo, _cameraCollider);
            cameraColliderCreator.CreateCollider();

            var blockSizeProvider = new BlockSizeInfoProvider(fieldInfo, _levelFieldConfig);
            var gridBuilder = new LevelGridBuilder(
                blockSizeProvider,
                serviceContainer.Get<IBlockCreator>(),
                fieldInfo);
            
            serviceContainer.SetService<ILevelGridBuilder, LevelGridBuilder>(gridBuilder);

            var checkCameraBorderSystem = new CheckCameraBordersSystem(fieldInfo);
            serviceContainer.SetService<ISystem, CheckCameraBordersSystem>(checkCameraBorderSystem);
            serviceContainer.SetServiceSelf(checkCameraBorderSystem);
        }
    }
}