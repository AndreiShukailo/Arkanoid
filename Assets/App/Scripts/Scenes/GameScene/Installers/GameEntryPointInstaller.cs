using System.Collections.Generic;
using App.Scripts.Infrastructure.EntryPoint;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Infrastructure.States;
using App.Scripts.Infrastructure.States.SetupState;
using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.Game.Block;
using App.Scripts.Scenes.Game.Block.View;
using App.Scripts.Scenes.Game.Level.Level;
using App.Scripts.Scenes.Game.Level.LevelField.Config;
using App.Scripts.Scenes.Game.Level.LevelField.Field;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.Game.Installers
{
    public class GameEntryPointInstaller : MonoInstaller
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private BlockView _blockView;
        [SerializeField] private Camera _camera;
        [SerializeField] private LevelFieldConfig _levelFieldConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var gameStateMachine = BuildStateMachine(serviceContainer);
            var controllerEntryPoint = new ControllerEntryPoint<StateSetupScene>(gameStateMachine);

            serviceContainer.SetService<IInitializable, ControllerEntryPoint<StateSetupScene>>(controllerEntryPoint);
            serviceContainer.SetService<IUpdatable, ControllerEntryPoint<StateSetupScene>>(controllerEntryPoint);

            var sceneLoaderController = serviceContainer.Get<SceneLoaderController>();
            _button.onClick.AddListener(() => sceneLoaderController.ProcessLoadScene(sceneLoaderController.ScenesConfig.StartScene).Forget());
        }

        private GameStateMachine BuildStateMachine(ServiceContainer serviceContainer)
        {
            var gameStateMachine = new GameStateMachine();

            gameStateMachine.AddState(CreateSetupState(serviceContainer));
            gameStateMachine.AddState(CreateProcessState(serviceContainer));

            return gameStateMachine;
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
            var textDataProvier = new TextDataProvider();
            var fieldInfo = new FieldProvider(_camera).CreateField(_levelFieldConfig);
            var blockCreator = new BlockCreator(_blockView);

            var handlers = new List<IHandlerSetupScene>
            {
                new HandlerSetupLevel(textDataProvier, _blockView, fieldInfo, blockCreator, _levelFieldConfig)
            };
            var handlerSetupSceneContainer = new HandlerSetupSceneContainer(handlers);

            return new StateSetupScene(handlerSetupSceneContainer, sceneLoader);
        }
    }
}