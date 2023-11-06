using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Config;
using App.Scripts.Scenes.GameScene.Ball.Factory;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class BallCreatorInstaller : MonoInstaller
    {
        [SerializeField] private BallConfig _ballConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var ballFactory =
                new BallFactory(_ballConfig.PoolSetting, 
                    serviceContainer.Get<CheckCameraBordersSystem>());

            var ballCreator = new BallCreator(_ballConfig, ballFactory);
            serviceContainer.SetService<IBallCreator, BallCreator>(ballCreator);
        }
    }
}