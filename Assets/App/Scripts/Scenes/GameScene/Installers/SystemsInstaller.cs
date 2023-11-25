using App.Scripts.Libs.Components;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private Transform _boosts;
        
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var systemsContainer = new SystemsContainer();
            serviceContainer.SetServiceSelf(systemsContainer);

            var collisionSystem = new CollisionSystem();
            systemsContainer.AddSystem<CollisionHandlerComponent, CollisionSystem>(collisionSystem);
            serviceContainer.SetService<ISystem, CollisionSystem>(collisionSystem);
            
            var correctAngle = new CorrectAngleSystem();
            systemsContainer.AddSystem<CorretionAngleComponent, CorrectAngleSystem>(correctAngle);
            serviceContainer.SetService<ISystem, CorrectAngleSystem>(correctAngle);
            
            var healthSystem = new HealthSystem();
            systemsContainer.AddSystem<HealthComponent, HealthSystem>(healthSystem);
            serviceContainer.SetService<ISystem, HealthSystem>(healthSystem);
            
            var movingSystem = new MovingSystem();
            systemsContainer.AddSystem<MovingComponent, MovingSystem>(movingSystem);
            serviceContainer.SetService<ISystem, MovingSystem>(movingSystem);
            
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