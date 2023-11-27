using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.UIMenegement;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Controller;
using App.Scripts.Scenes.GameScene.HudFeature.HealthBar.Factory;
using App.Scripts.Scenes.GameScene.Level.LevelProgressInfo;
using App.Scripts.Scenes.GameScene.PopUpsFeature;
using App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp;
using App.Scripts.Scenes.GameScene.PopUpsFeature.MenuPopUp;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp;
using App.Scripts.Scenes.PackSelectScene.Features.PopUpFeature;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private HealthBarView _healthBarView;
        [SerializeField] private HealthItemView _healthItemView;
        [SerializeField] private LevelProgressInfoView LevelProgressInfoView;
        [Header("MenuPopUp")] [SerializeField] private MenuPopupPoolSetting _menuPupUpPoolSetting;

        [Header("VictoryPopUp")] [SerializeField]
        private VictoryPopUpPoolSetting _victoryPopUpPoolSetting;

        [Header("LosePopUp")] [SerializeField] private LosePopUpPoolSetting _losePopUpPoolSetting;

        [Header("NoEnergyPopUp")] [SerializeField]
        private NoEnergyPopUpPoolSetting _noEnergyPopUpPoolSetting;

        [Header("BlockedUI")] [SerializeField] private GraphicRaycaster _blockedUI;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(new BlockUIController(_blockedUI));

            var commandSpendEnergy = new CommandSpendEnergy(
                serviceContainer.Get<EnergyController>(),
                serviceContainer.Get<EnergyViewController>(),
                serviceContainer.Get<CommandChangeState>(),
                serviceContainer.Get<HealthController>(),
                InstallNoEnergyPopUp(serviceContainer));

            InstallLosePopup(serviceContainer, commandSpendEnergy);
            InstallMenuPopup(serviceContainer, commandSpendEnergy);
            InstallVictoryPopUp(serviceContainer, commandSpendEnergy);
            InstallHealthBarView(serviceContainer);
            InstallLevelProgressInfoView(serviceContainer);
        }

        private NoEnergyPopUpController InstallNoEnergyPopUp(ServiceContainer serviceContainer)
        {
            var noEnergyPopUp = new NoEnergyPopUpController(
                serviceContainer.Get<PopUpController>(), serviceContainer.Get<ButtonManager>());

            var popUpContainer = serviceContainer.Get<PopUpContainer>();
            popUpContainer.AddPopUp<NoEnergyPopUp>(_noEnergyPopUpPoolSetting);
            return noEnergyPopUp;
        }

        private void InstallLosePopup(ServiceContainer serviceContainer, CommandSpendEnergy commandSpendEnergy)
        {
            serviceContainer.SetServiceSelf(new LosePopUpController(
                serviceContainer.Get<ButtonManager>(),
                serviceContainer.Get<PopUpController>(),
                serviceContainer.Get<EnergyViewController>(),
                commandSpendEnergy,
                serviceContainer.Get<SceneLoaderController>()));

            var popUpContainer = serviceContainer.Get<PopUpContainer>();
            popUpContainer.AddPopUp<LosePopup>(_losePopUpPoolSetting);
        }

        private void InstallMenuPopup(ServiceContainer serviceContainer, CommandSpendEnergy commandSpendEnergy)
        {
            serviceContainer.SetServiceSelf(new MenuPopupController(
                serviceContainer.Get<ButtonManager>(),
                serviceContainer.Get<CommandChangeState>(),
                serviceContainer.Get<SceneLoaderController>(),
                serviceContainer.Get<PopUpController>(),
                serviceContainer.Get<EnergyViewController>(), commandSpendEnergy));

            var popUpContainer = serviceContainer.Get<PopUpContainer>();
            popUpContainer.AddPopUp<MenuPopUp>(_menuPupUpPoolSetting);
        }

        private void InstallVictoryPopUp(ServiceContainer serviceContainer, CommandSpendEnergy commandSpendEnergy)
        {
            serviceContainer.SetServiceSelf(new VictoryPopUpController(
                serviceContainer.Get<ButtonManager>(),
                serviceContainer.Get<CommandChangeState>(),
                serviceContainer.Get<PopUpController>(),
                serviceContainer.Get<SceneLoaderController>(),
                serviceContainer.Get<EnergyViewController>(), commandSpendEnergy));

            var popUpContainer = serviceContainer.Get<PopUpContainer>();
            popUpContainer.AddPopUp<VictoryPopUp>(_victoryPopUpPoolSetting);
        }

        private void InstallLevelProgressInfoView(ServiceContainer serviceContainer)
        {
            LevelProgressInfoView.Construct(serviceContainer.Get<LevelProgressInfoController>());
        }

        private void InstallHealthBarView(ServiceContainer serviceContainer)
        {
            _healthBarView.Construct(
                serviceContainer.Get<HealthController>(),
                new HealthItemFactory(_healthItemView, _healthBarView));
        }
    }
}