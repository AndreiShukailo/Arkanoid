using App.Scripts.Libs.Components;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using App.Scripts.Scenes.GameScene.Platform.Components;
using App.Scripts.Scenes.GameScene.Platform.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private Transform _boosts;
        [SerializeField] private ComponentContainerPoolSetting _bulletPoolSetting;
        
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var systemsContainer = new SystemsContainer();
            serviceContainer.SetServiceSelf(systemsContainer);

            var collisionSystem = new CollisionSystem(
                new SimpleCollisionAction(), 
                new FireBallCollisionAction(),
                new BulletCollisionAction());
            systemsContainer.AddSystem<CollisionHandlerComponent, CollisionSystem>(collisionSystem);
            serviceContainer.SetService<ISystem, CollisionSystem>(collisionSystem);
            
            var correctAngle = new CorrectAngleSystem();
            systemsContainer.AddSystem<CorretionAngleComponent, CorrectAngleSystem>(correctAngle);
            serviceContainer.SetService<ISystem, CorrectAngleSystem>(correctAngle);
            
            var gunSystem = new GunSystem(new BulletFactory(_bulletPoolSetting, systemsContainer));
            systemsContainer.AddSystem<GunComponent, GunSystem>(gunSystem);
            serviceContainer.SetService<ISystem, GunSystem>(gunSystem);
            
            var healthSystem = new HealthSystem();
            systemsContainer.AddSystem<HealthComponent, HealthSystem>(healthSystem);
            serviceContainer.SetService<ISystem, HealthSystem>(healthSystem);
            
            var speedComplicationSystem = new SpeedComplicationSystem();
            systemsContainer.AddSystem<SpeedComplicationComponent, SpeedComplicationSystem>(speedComplicationSystem);
            serviceContainer.SetService<ISystem, SpeedComplicationSystem>(speedComplicationSystem);
            serviceContainer.SetServiceSelf(speedComplicationSystem);
            
            var spawnBoostSystem = new SpawnBoostSystem(systemsContainer, _boosts);
            systemsContainer.AddSystem<SpawnBoostComponent, SpawnBoostSystem>(spawnBoostSystem);
            serviceContainer.SetService<ISystem, SpawnBoostSystem>(spawnBoostSystem);
            
            var boostComponent = new BoostActivatorSystem();
            systemsContainer.AddSystem<BoostActivatorComponent, BoostActivatorSystem>(boostComponent);
            serviceContainer.SetService<ISystem, BoostActivatorSystem>(boostComponent);
        }
    }
}