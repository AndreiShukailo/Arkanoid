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
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.Level.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.Level.Handlers;
using App.Scripts.Scenes.GameScene.Platform;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class GameEntryPointInstaller : MonoInstaller
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
            gameStateMachine.AddState(CreateReloadLevelState(serviceContainer));
            gameStateMachine.AddState(CreateLoadSceneState(serviceContainer));

            return gameStateMachine;
        }

        private LoadSceneState CreateLoadSceneState(ServiceContainer serviceContainer)
        {
            var loadSceneState = new LoadSceneState(
                serviceContainer.Get<SceneLoaderController>(),
                serviceContainer.Get<PopUpController>());

            return loadSceneState;
        }

        private GameState CreateProcessState(ServiceContainer serviceContainer)
        {
            serviceContainer.SetService<ISystem, CheckLooseBallSystem>(
                new CheckLooseBallSystem(serviceContainer.Get<LevelController>()));

            var systems = serviceContainer.GetServices<ISystem>();
            var gameSystems = new SystemsGroup(systems);

            return new StateProcessGame(gameSystems);
        }

        private StateSetupScene CreateSetupState(ServiceContainer serviceContainer, GameStateMachine gameStateMachine)
        {
            var sceneLoader = serviceContainer.Get<SceneLoaderController>();
            var levelController = new LevelController(serviceContainer.Get<BallContainer>(), gameStateMachine);
            serviceContainer.SetServiceSelf(levelController);

            var handlerSetupLevel = new HandlerSetupLevel(
                levelController,
                serviceContainer.Get<ILevelCreator>(),
                serviceContainer.Get<IBallCreator>(),
                serviceContainer.Get<IPlatformCreator>());

            serviceContainer.SetServiceSelf(handlerSetupLevel);

            var handlers = new List<IHandlerSetupScene>
            {
                handlerSetupLevel
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new StateSetupScene(handlerSetupSceneContainer, sceneLoader);
        }

        private ReloadLevelState CreateReloadLevelState(ServiceContainer serviceContainer)
        {
            var handlers = new List<IHandlerSetupScene>
            {
                new HandlerClearLevel(serviceContainer.Get<LevelController>()),
                serviceContainer.Get<HandlerSetupLevel>()
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new ReloadLevelState(handlerSetupSceneContainer);
        }
    }
}