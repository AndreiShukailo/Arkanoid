using System.Collections.Generic;
using App.Scripts.Infrastructure.EntryPoint;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.StartScene.States;

namespace App.Scripts.Scenes.StartScene.Installers
{
    public class StartEntryPointInstaller : MonoInstaller
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

            gameStateMachine.AddState(CreateSetupState(serviceContainer, gameStateMachine));
            gameStateMachine.AddState(CreateProcessState(serviceContainer));
            gameStateMachine.AddState(CreteLanguagePopupState(serviceContainer));
            gameStateMachine.AddState(CreateLoadSceneState(serviceContainer));

            return gameStateMachine;
        }

        private GameState CreteLanguagePopupState(ServiceContainer serviceContainer)
        {
            return new ChoseLanguageState(serviceContainer.Get<PopUpController>());
        }

        private LoadSceneState CreateLoadSceneState(ServiceContainer serviceContainer)
        {
            var loadSceneState = new LoadSceneState(
                serviceContainer.Get<SceneLoaderController>(),
                serviceContainer.Get<PopUpController>());

            return loadSceneState;
        }

        private StateSetupScene CreateSetupState(ServiceContainer serviceContainer, GameStateMachine gameStateMachine)
        {
            var sceneLoader = serviceContainer.Get<SceneLoaderController>();

            var handlers = new List<IHandlerSetupScene>()
            {
                new HandlerSetupButtons(serviceContainer.Get<ButtonsContainer>(), gameStateMachine, sceneLoader)
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new StateSetupScene(handlerSetupSceneContainer, sceneLoader);
        }

        private GameState CreateProcessState(ServiceContainer serviceContainer)
        {
            var systems = serviceContainer.GetServices<ISystem>();
            var gameSystems = new SystemsGroup(systems);

            return new StateProcessGame(gameSystems);
        }
    }
}