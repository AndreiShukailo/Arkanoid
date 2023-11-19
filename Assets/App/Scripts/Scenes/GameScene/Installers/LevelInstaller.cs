using App.Scripts.Infrastructure;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Libs.TiledParser.Tiled;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Level.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Config;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using App.Scripts.Scenes.GameScene.Level.PackInfoFeature;
using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.Platform.Config;
using App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private int _startHealthCount = 4;
        [SerializeField] private LevelsConfig _levelsConfig;
        
        [Header("PlatformSetting")]
        [SerializeField] private PlatformConfig _platformConfig;
        [Header("BallSetting")]
        [SerializeField] private BallConfig _ballConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(new HealthController(_startHealthCount));
            serviceContainer.SetServiceSelf(new LevelProgressInfoController(serviceContainer.Get<PackController>()));
            
            serviceContainer.SetService<ILevelCreator, LevelCreator>(CreateLevelCreator(serviceContainer));
            
            var levelController = CreateLevelController(serviceContainer);
            serviceContainer.SetServiceSelf(levelController);

            var deathSystem = CreateDeathSystem(serviceContainer, levelController);
            serviceContainer.SetService<ISystem, DeathSystem>(deathSystem);
            
            var checkLooseBallSystem = CreateLooseBallSystem(serviceContainer, levelController);
            serviceContainer.SetService<ISystem, CheckLooseBallSystem>(checkLooseBallSystem);
            
            InstallPlatformCreator(serviceContainer);
            InstallBallCreator(serviceContainer);
        }

        private LevelCreator CreateLevelCreator(ServiceContainer serviceContainer)
        {
            var tiledMapProvider = new TiledMapProvider(serviceContainer.Get<TextDataProvider>());
            var levelParser = new LevelParser(tiledMapProvider);
            var levelPathCreator = new LevelPathCreator(
                _levelsConfig,
                serviceContainer.Get<PackController>());
            return new LevelCreator(
                serviceContainer.Get<ILevelGridBuilder>(),
                levelParser,
                levelPathCreator);
        }
        
        private LevelController CreateLevelController(ServiceContainer serviceContainer)
        {
            var levelController = new LevelController(
                new BallContainer(), 
                serviceContainer.Get<HealthController>(),
                serviceContainer.Get<CommandChangeState>(),
                serviceContainer.Get<LevelProgressInfoController>());

            return levelController;
        }

        private DeathSystem CreateDeathSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var deathSystem = new DeathSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<DeathComponent, DeathSystem>(deathSystem);
            return deathSystem;
        }

        private CheckLooseBallSystem CreateLooseBallSystem(ServiceContainer serviceContainer, LevelController levelController)
        {
            return new CheckLooseBallSystem(levelController, serviceContainer.Get<FieldInfo>());
        }

        private void InstallPlatformCreator(ServiceContainer serviceContainer)
        {
            var platformCreator = new PlatformCreator(
                _platformConfig,
                serviceContainer.Get<FieldInfo>(),
                serviceContainer.Get<SystemsContainer>());
            serviceContainer.SetService<IPlatformCreator, PlatformCreator>(platformCreator);
        }

        private void InstallBallCreator(ServiceContainer serviceContainer)
        {
            var ballCreator = new BallCreator(_ballConfig, serviceContainer.Get<SystemsContainer>());
            serviceContainer.SetService<IBallCreator, BallCreator>(ballCreator);
        }
    }
}