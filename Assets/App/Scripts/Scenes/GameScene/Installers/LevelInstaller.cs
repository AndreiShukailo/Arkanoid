using App.Scripts.Infrastructure.Effects;
using App.Scripts.Infrastructure.Effects.View;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Components;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Libs.TiledParser.Tiled;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Block.BombsFeature;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostAddBall;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostBallSpeed;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostFireBall;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSize;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.BoostPlatformSpeed;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.GunBoost;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.HealthChangeBoost;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.Level.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Config;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using App.Scripts.Scenes.GameScene.Level.LevelProgressInfo;
using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.Platform.Config;
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
        [Header("Other")]
        [SerializeField] private EffectViewPoolSetting _bombEffectPoolSetting;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var healthController = new HealthController(_startHealthCount);
            serviceContainer.SetServiceSelf(healthController);
            serviceContainer.SetServiceSelf(new LevelProgressInfoController(serviceContainer.Get<PackController>()));
            
            serviceContainer.SetService<ILevelCreator, LevelCreator>(CreateLevelCreator(serviceContainer));
            
            var levelController = CreateLevelController(serviceContainer);
            serviceContainer.SetServiceSelf(levelController);
            
            serviceContainer.SetService<ISystem, DeathSystem>(CreateDeathSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, BombSystem>(CreateBombSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, CheckLooseBallSystem>(CreateLooseBallSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, BoostBallSpedSystem>(CreateBoostBallSpeedSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, BoostPlatformSizeSystem>(CreateBoostPlatformSizeSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, BoostFireBallSystem>(CreateBoostFireBallSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, BoostPlatformSpeedSystem>(CreateBoostPlatformSpeedSystem(serviceContainer, levelController));
            serviceContainer.SetService<ISystem, HealthChangeBoostSystem>(CreateChangeHealthSystem(serviceContainer, healthController));
            serviceContainer.SetService<ISystem, GunBoosSystem>(CreateGunBoostSystem(serviceContainer, levelController));
            
            InstallPlatformCreator(serviceContainer);
            InstallBallCreator(serviceContainer);
            
            serviceContainer.SetService<ISystem, BoostAddBallSystem>(CreateBoostAddBallSystem(serviceContainer, levelController));
        }

        private BombSystem CreateBombSystem(ServiceContainer serviceContainer, LevelController levelController)
        {
            var commandBombBlocks = new CommandBombBlocks(levelController, new EffectViewFactory(_bombEffectPoolSetting));
            var bombSystem = new BombSystem(commandBombBlocks, this);
            serviceContainer.Get<SystemsContainer>().AddSystem<BombComponent, BombSystem>(bombSystem);
            return bombSystem;
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
                serviceContainer.Get<LevelProgressInfoController>(),
                serviceContainer.Get<SpeedComplicationSystem>());

            return levelController;
        }

        private DeathSystem CreateDeathSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var deathSystem = new DeathSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<DeathComponent, DeathSystem>(deathSystem);
            return deathSystem;
        }
        
        private GunBoosSystem CreateGunBoostSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var gunBoostSystem = new GunBoosSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<GunBoostComponent, GunBoosSystem>(gunBoostSystem);
            return gunBoostSystem;
        }
        
        private BoostBallSpedSystem CreateBoostBallSpeedSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var boostBallSpeedSystem = new BoostBallSpedSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<BoostBallSpeedComponent, BoostBallSpedSystem>(boostBallSpeedSystem);
            return boostBallSpeedSystem;
        }
        
        private BoostPlatformSpeedSystem CreateBoostPlatformSpeedSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var boostPlatformSpeedSystem = new BoostPlatformSpeedSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<BoostPlatformSpeedComponent, BoostPlatformSpeedSystem>(boostPlatformSpeedSystem);
            return boostPlatformSpeedSystem;
        }
        
        private BoostPlatformSizeSystem CreateBoostPlatformSizeSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var boostPlatformSizeSystem = new BoostPlatformSizeSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<BoostPlatformSizeComponent, BoostPlatformSizeSystem>(boostPlatformSizeSystem);
            return boostPlatformSizeSystem;
        }
        
        private BoostFireBallSystem CreateBoostFireBallSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var boostFireBallSystem = new BoostFireBallSystem(levelController);
            serviceContainer.Get<SystemsContainer>().AddSystem<BoostFireBallComponent, BoostFireBallSystem>(boostFireBallSystem);
            return boostFireBallSystem;
        }
        
        private HealthChangeBoostSystem CreateChangeHealthSystem(ServiceContainer serviceContainer, HealthController healthController)
        {
            var changeHealthBoostSystem = new HealthChangeBoostSystem(healthController);
            serviceContainer.Get<SystemsContainer>().AddSystem<HealthChangeComponent, HealthChangeBoostSystem>(changeHealthBoostSystem);
            return changeHealthBoostSystem;
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
        private BoostAddBallSystem CreateBoostAddBallSystem(ServiceContainer serviceContainer, LevelController levelController)
        {           
            var boostAddBAllSystem = new BoostAddBallSystem(levelController, serviceContainer.Get<IBallCreator>());
            serviceContainer.Get<SystemsContainer>().AddSystem<BoostAddBallComponent, BoostAddBallSystem>(boostAddBAllSystem);
            return boostAddBAllSystem;
        }
    }
}