using System.Collections.Generic;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.Buttons.Container;
using App.Scripts.Infrastructure.EnergyFeature.View;
using App.Scripts.Infrastructure.EntryPoint;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Infrastructure.TimeManagement;
using App.Scripts.Libs.Components;
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
using App.Scripts.Scenes.GameScene.Level.View;
using App.Scripts.Scenes.GameScene.Platform;
using App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp;
using App.Scripts.Scenes.GameScene.PopUpsFeature.MenuPopUp;
using App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp;

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
            gameStateMachine.AddState(CreateSkipLevelState(serviceContainer));

            serviceContainer.Get<CommandChangeState>().AddStateMachine(gameStateMachine);

            return gameStateMachine;
        }

        private GameState CreateLoseState(ServiceContainer serviceContainer)
        {
            var state = new LoseState(serviceContainer.Get<LosePopUpController>(),
                serviceContainer.Get<TimeManager>());

            return state;
        }

        private GameState CreateSkipLevelState(ServiceContainer serviceContainer)
        {
            var state = new SkipLevelState(new HandlerProcessSkipLevel(serviceContainer.Get<LevelController>(),
                serviceContainer.Get<PopUpController>()));
            return state;
        }

        private GameState CreateVictoryState(ServiceContainer serviceContainer)
        {
            var victoryPopUpController = serviceContainer.Get<VictoryPopUpController>();

            var state = new VictoryState(
                new HandlerProcessVictory(serviceContainer.Get<PackController>(),
                    victoryPopUpController,
                    serviceContainer.Get<LocalizationController>(),
                    serviceContainer.Get<EnergyViewController>()),
                victoryPopUpController,
                serviceContainer.Get<TimeManager>(),
                new HandlerTransitToVictory(serviceContainer.Get<LevelController>(),
                    serviceContainer.Get<ConfettiEffectView>(),
                    serviceContainer.Get<PopUpController>(), 
                    serviceContainer.Get<SystemsContainer>()));
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
                serviceContainer.Get<PopUpController>(),
                serviceContainer.Get<EnergyViewController>(),
                serviceContainer.Get<TimeManager>());

            return loadSceneState;
        }

        private GameState CreateProcessState(ServiceContainer serviceContainer)
        {
            var systems = serviceContainer.GetServices<ISystem>();
            var gameSystems = new SystemsGroup(systems);
            serviceContainer.SetServiceSelf(gameSystems);

            return new StateProcessGame(gameSystems, serviceContainer.Get<TimeManager>());
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
            var handlerClearPlatform = new HandlerClearPlatform(serviceContainer.Get<LevelController>(),
                serviceContainer.Get<SystemsGroup>());
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
                new HandlerClearLevel(serviceContainer.Get<LevelController>(),
                    serviceContainer.Get<SystemsContainer>()),
                serviceContainer.Get<HandlerSetupLevel>(),
                serviceContainer.Get<HandlerSetupPlatform>()
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new ReloadLevelState(handlerSetupSceneContainer);
        }
    }
}