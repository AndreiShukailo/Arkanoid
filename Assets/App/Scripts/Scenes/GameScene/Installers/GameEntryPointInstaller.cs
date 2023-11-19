using System.Collections.Generic;
using App.Scripts.Infrastructure;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.EntryPoint;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball;
using App.Scripts.Scenes.GameScene.GameStates;
using App.Scripts.Scenes.GameScene.Level;
using App.Scripts.Scenes.GameScene.Level.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Controller;
using App.Scripts.Scenes.GameScene.Level.Level.Handlers;
using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp;
using App.Scripts.Scenes.StartScene.Language.PopUp;

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

            gameStateMachine.AddState(CreateSetupState(serviceContainer));
            gameStateMachine.AddState(CreateProcessState(serviceContainer));
            gameStateMachine.AddState(CreateMenuState(serviceContainer));
            gameStateMachine.AddState(CreateLoseState(serviceContainer));
            gameStateMachine.AddState(CreateVictoryState(serviceContainer));
            gameStateMachine.AddState(CreateReloadPlatformState(serviceContainer));
            gameStateMachine.AddState(CreateReloadLevelState(serviceContainer));
            gameStateMachine.AddState(CreateLoadSceneState(serviceContainer));

            serviceContainer.Get<CommandChangeState>().AddStateMachine(gameStateMachine);

            return gameStateMachine;
        }

        private GameState CreateLoseState(ServiceContainer serviceContainer)
        {
            var state = new LoseState(serviceContainer.Get<LosePopUpController>(),
                serviceContainer.Get<TimeManager>());
            
            return state;
        }

        private GameState CreateVictoryState(ServiceContainer serviceContainer)
        {
            var state = new VictoryState(
                serviceContainer.Get<PackController>(), 
                serviceContainer.Get<VictoryPopUpController>(),
                serviceContainer.Get<LocalizationController>(),
                serviceContainer.Get<TimeManager>());
            return state;
        }

        private GameState CreateMenuState(ServiceContainer serviceContainer)
        {
            var menuState = new MenuState(
                serviceContainer.Get<MenuPopupController>(),
                serviceContainer.Get<TimeManager>());

            return menuState;
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
            var systems = serviceContainer.GetServices<ISystem>();
            var gameSystems = new SystemsGroup(systems);

            return new StateProcessGame(gameSystems);
        }

        private StateSetupScene CreateSetupState(ServiceContainer serviceContainer)
        {
            var sceneLoader = serviceContainer.Get<SceneLoaderController>();

            var handlerSetupLevel = new HandlerSetupLevel(
                serviceContainer.Get<LevelController>(),
                serviceContainer.Get<ILevelCreator>(),
                serviceContainer.Get<PackController>());
            serviceContainer.SetServiceSelf(handlerSetupLevel);

            var handlerSetupPlatform = new HandlerSetupPlatform(
                serviceContainer.Get<LevelController>(),
                serviceContainer.Get<IBallCreator>(),
                serviceContainer.Get<IPlatformCreator>());
            serviceContainer.SetServiceSelf(handlerSetupPlatform);


            var handlers = new List<IHandlerSetupScene>
            {
                handlerSetupLevel,
                handlerSetupPlatform,
                new HandlerSetupButtonsGameScene(
                    serviceContainer.Get<ButtonsContainer>(),
                    sceneLoader,
                    serviceContainer.Get<CommandChangeState>())
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new StateSetupScene(
                handlerSetupSceneContainer,
                sceneLoader,
                serviceContainer.Get<ButtonManager>());
        }

        private GameState CreateReloadPlatformState(ServiceContainer serviceContainer)
        {
            var handlerClearPlatform = new HandlerClearPlatform(serviceContainer.Get<LevelController>());
            serviceContainer.SetServiceSelf(handlerClearPlatform);

            var handlers = new List<IHandlerSetupScene>
            {
                handlerClearPlatform,
                serviceContainer.Get<HandlerSetupPlatform>()
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new ReloadPlatformState(handlerSetupSceneContainer);
        }

        private ReloadLevelState CreateReloadLevelState(ServiceContainer serviceContainer)
        {
            var handlers = new List<IHandlerSetupScene>
            {
                serviceContainer.Get<HandlerClearPlatform>(),
                new HandlerClearLevel(serviceContainer.Get<LevelController>()),
                serviceContainer.Get<HandlerSetupLevel>(),
                serviceContainer.Get<HandlerSetupPlatform>()
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new ReloadLevelState(handlerSetupSceneContainer);
        }
    }
}