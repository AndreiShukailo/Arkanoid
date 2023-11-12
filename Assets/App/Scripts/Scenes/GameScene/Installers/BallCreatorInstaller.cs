using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class BallCreatorInstaller : MonoInstaller
    {
        [SerializeField] private BallConfig _ballConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var ballFactory =
                new BallFactory(_ballConfig.PoolSetting);

            var ballCreator = new BallCreator(_ballConfig, ballFactory);
            serviceContainer.SetService<IBallCreator, BallCreator>(ballCreator);

            var ballContainer = new BallContainer();
            serviceContainer.SetServiceSelf(ballContainer);
        }
    }
}