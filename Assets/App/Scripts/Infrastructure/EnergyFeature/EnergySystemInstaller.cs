using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.EnergyFeature.Config;
using App.Scripts.Infrastructure.EnergyFeature.Factory;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.EnergyFeature
{
    public class EnergySystemInstaller : MonoInstaller
    {
        [SerializeField] private EnergyConfig _energyConfig;
        [SerializeField] private EnergyPollSetting _energyPollSetting;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var energyController = new EnergyController(serviceContainer.Get<SaveLoadService>(), _energyConfig);
            serviceContainer.SetServiceSelf(energyController);
            var energyViewController = new EnergyViewController(energyController, _energyPollSetting,
                serviceContainer.Get<ButtonsViewContainer>().Container);
            var energyTimerSystem = new EnergyTimerSystem(energyController, energyViewController);
            energyTimerSystem.StartTimer();
            serviceContainer.SetServiceSelf(energyViewController);
        }
    }
}