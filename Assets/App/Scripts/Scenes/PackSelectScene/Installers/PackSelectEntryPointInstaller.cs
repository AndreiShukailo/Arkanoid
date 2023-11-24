using System.Collections.Generic;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.EnergyFeature;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.EntryPoint;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.PackSelectScene.Features;
using App.Scripts.Scenes.PackSelectScene.Features.ButtonsFeature;
using App.Scripts.Scenes.PackSelectScene.Features.EnergySetupView;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature;
using App.Scripts.Scenes.PackSelectScene.PackSelectedStates;

namespace App.Scripts.Scenes.PackSelectScene.Installers
{
    public class PackSelectEntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var gameStateMachine = BuildStateMachine(serviceContainer);
            var controllerEntryPoint = new ControllerEntryPoint<StateSetupScene>(gameStateMachine);

            serviceContainer.SetService<IInitializable, ControllerEntryPoint<StateSetupScene>>(controllerEntryPoint);
            serviceContainer.SetService<IUpdatable, ControllerEntryPoint<StateSetupScene>>(controllerEntryPoint);
        }

        private GameStateMachine BuildStateMachine(ServiceContainer serviceContainer)
        {
            var gameStateMachine = new GameStateMachine();

            gameStateMachine.AddState(CreateTransitState(serviceContainer));
            gameStateMachine.AddState(CreateSetupState(serviceContainer));
            gameStateMachine.AddState(CreateProcessState(serviceContainer));
            gameStateMachine.AddState(CreateLoadSceneState(serviceContainer));

            serviceContainer.Get<CommandChangeState>().AddStateMachine(gameStateMachine);

            return gameStateMachine;
        }

        private GameState CreateTransitState(ServiceContainer serviceContainer)
        {
            var handlerSetupButtons = new HandlerSetupButtonsPackSelectedScene(
                serviceContainer.Get<ButtonsContainer>(),
                serviceContainer.Get<SceneLoaderController>());
            serviceContainer.SetServiceSelf(handlerSetupButtons);

            return new TransitOnGameSceneState(
                serviceContainer.Get<EnergyViewController>(),
                serviceContainer.Get<SceneLoaderController>(),
                handlerSetupButtons,
                serviceContainer.Get<PacksCreator>());
        }

        private LoadSceneState CreateLoadSceneState(ServiceContainer serviceContainer)
        {
            var loadSceneState = new LoadSceneState(
                serviceContainer.Get<SceneLoaderController>(),
                serviceContainer.Get<PopUpController>(),
                serviceContainer.Get<EnergyViewController>());

            return loadSceneState;
        }

        private StateSetupScene CreateSetupState(ServiceContainer serviceContainer)
        {
            var sceneLoader = serviceContainer.Get<SceneLoaderController>();

            var handlers = new List<IHandlerSetupScene>()
            {
                new HandlerCreatePacks(serviceContainer.Get<PacksCreator>()),
                serviceContainer.Get<HandlerSetupButtonsPackSelectedScene>(),
                new HandlerSetupEnergy(
                    serviceContainer.Get<EnergyViewController>(),
                    serviceContainer.Get<EnergyContainer>())
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new StateSetupScene(
                handlerSetupSceneContainer,
                sceneLoader,
                serviceContainer.Get<ButtonManager>());
        }

        private GameState CreateProcessState(ServiceContainer serviceContainer)
        {
            var systems = serviceContainer.GetServices<ISystem>();
            var gameSystems = new SystemsGroup(systems);

            return new StateProcessGame(gameSystems);
        }
    }
}