using App.Scripts.Infrastructure.ProjectSettings.Config;
using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.ProjectSettings.Installers
{
    public class InstallerProjectSettings : MonoInstaller
    {
        [SerializeField] private ConfigProjectSettings _configProjectSettings;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var controller = new ControllerSetupProjectSettings(_configProjectSettings);
            var timeManager = new TimeManager();
            serviceContainer.SetServiceSelf(timeManager);

            serviceContainer.SetService<IInitializable, ControllerSetupProjectSettings>(controller);
        }
    }
}