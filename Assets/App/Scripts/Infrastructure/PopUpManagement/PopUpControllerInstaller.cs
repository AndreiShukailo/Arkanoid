using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.ServiceLocator;

namespace App.Scripts.Infrastructure.PopUpManagement
{
    public class PopUpControllerInstaller : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var popUpController = new PopUpController(serviceContainer.Get<LocalizationController>());
            serviceContainer.SetServiceSelf(popUpController);
        }
    }
}