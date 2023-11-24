using App.Scripts.Libs.Components;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Block;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Input;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder;
using App.Scripts.Scenes.GameScene.Level.LevelField.BlockSize;
using App.Scripts.Scenes.GameScene.Level.LevelField.CameraBorders;
using App.Scripts.Scenes.GameScene.Level.LevelField.Config;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using App.Scripts.Scenes.GameScene.Platform.Components;
using App.Scripts.Scenes.GameScene.Platform.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class LevelFieldInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LevelFieldConfig _levelFieldConfig;
        [SerializeField] private CameraBordersContainer _cameraBordersContainer;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var fieldInfo = new FieldProvider(_camera)
                .CreateField(_levelFieldConfig);
            serviceContainer.SetServiceSelf(fieldInfo);
            
            InstallDestroyWhenInvisibleSystem(serviceContainer, fieldInfo);

            _cameraBordersContainer.Register(
                fieldInfo,
                new CameraBordersFactory(serviceContainer.Get<SystemsContainer>()));

            CreateGridBuilder(serviceContainer, fieldInfo);
            CreateInputSystem(serviceContainer, fieldInfo);
        }

        private void CreateGridBuilder(ServiceContainer serviceContainer, FieldInfo fieldInfo)
        {
            var blockSizeProvider = new BlockSizeInfoProvider(fieldInfo, _levelFieldConfig);
            var gridBuilder = new LevelGridBuilder(
                blockSizeProvider,
                serviceContainer.Get<IBlockCreator>(),
                fieldInfo);

            serviceContainer.SetService<ILevelGridBuilder, LevelGridBuilder>(gridBuilder);
        }

        private void CreateInputSystem(ServiceContainer serviceContainer, FieldInfo fieldInfo)
        {
            var inputSystem = new InputSystem(_camera, fieldInfo);
            serviceContainer.SetService<ISystem, InputSystem>(inputSystem);

            var controlMoveSystem = new ControlMoveSystem(inputSystem);
            serviceContainer.Get<SystemsContainer>()
                .AddSystem<ControlMovementComponent, ControlMoveSystem>(controlMoveSystem);
            serviceContainer.SetService<ISystem, ControlMoveSystem>(controlMoveSystem);
            
            var movingWithPlatformSystem = new MovingWithPlatformSystem(inputSystem);
            serviceContainer.Get<SystemsContainer>()
                .AddSystem<MovingWithPlatformComponent, MovingWithPlatformSystem>(movingWithPlatformSystem);
            serviceContainer.SetService<ISystem, MovingWithPlatformSystem>(movingWithPlatformSystem);
        }

        private void InstallDestroyWhenInvisibleSystem(ServiceContainer serviceContainer, FieldInfo fieldInfo)
        {
            var destroyWhenInvisibleSystem = new DestroyWhenInvisibleSystem(fieldInfo);
            serviceContainer.Get<SystemsContainer>()
                .AddSystem<DestroyWhenInvisibleComponent, DestroyWhenInvisibleSystem>(destroyWhenInvisibleSystem);
            serviceContainer.SetService<ISystem, DestroyWhenInvisibleSystem>(destroyWhenInvisibleSystem);
            serviceContainer.SetServiceSelf(destroyWhenInvisibleSystem);
        }
    }
}