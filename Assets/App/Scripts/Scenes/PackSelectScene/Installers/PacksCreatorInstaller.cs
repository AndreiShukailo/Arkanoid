using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.PackSelectScene.Features.EnergySetupView;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.Factory;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View;
using App.Scripts.Scenes.PackSelectScene.Features.PopUpFeature;
using UnityEngine;

namespace App.Scripts.Scenes.PackSelectScene.Installers
{
    public class PacksCreatorInstaller : MonoInstaller
    {
        [SerializeField] private PackViewContainer _packContainer;
        [SerializeField] private Transform _content;
        [SerializeField] private EnergyContainer _energyContainer;
        [SerializeField] private NoEnergyPopUpPoolSetting _noEnergyPopUpPoolSetting;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            InstallNoEnergyPopUp(serviceContainer);
            
            var packCreator = new PacksCreator(
                serviceContainer.Get<PackController>(),
                new PackFactory(serviceContainer.Get<LocalizationController>(), _content),
                _packContainer,
                serviceContainer.Get<CommandChangeState>(), 
                serviceContainer.Get<NoEnergyPopUpController>());

            serviceContainer.SetServiceSelf(packCreator);
            serviceContainer.SetServiceSelf(_energyContainer);

        }

        private void InstallNoEnergyPopUp(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(new NoEnergyPopUpController(
                serviceContainer.Get<PopUpController>(), serviceContainer.Get<ButtonManager>()));

            var popUpContainer = serviceContainer.Get<PopUpContainer>();
            popUpContainer.AddPopUp<NoEnergyPopUp>(_noEnergyPopUpPoolSetting);
        }
    }
}