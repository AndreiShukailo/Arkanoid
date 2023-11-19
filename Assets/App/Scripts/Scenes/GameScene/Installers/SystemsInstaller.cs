using App.Scripts.Libs.Components;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.Systems;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var systemsContainer = new SystemsContainer();
            serviceContainer.SetServiceSelf(systemsContainer);

            var collisionSystem = new CollisionSystem(systemsContainer);
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
        }
    }
}