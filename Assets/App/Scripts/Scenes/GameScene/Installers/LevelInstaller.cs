using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.TiledParser.Level;
using App.Scripts.Libs.TiledParser.Tiled;
using App.Scripts.Scenes.GameScene.Level.Level;
using App.Scripts.Scenes.GameScene.Level.Level.Config;
using App.Scripts.Scenes.GameScene.Level.Level.LevelGrid.GridBuilder;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelsConfig _levelsConfig;
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetService<ILevelCreator, LevelCreator>(CreateLevelCreator(serviceContainer));
        }

        private LevelCreator CreateLevelCreator(ServiceContainer serviceContainer)
        {
            var tiledMapProvider = new TiledMapProvider(serviceContainer.Get<TextDataProvider>());
            var levelParser = new LevelParser(tiledMapProvider);
            var levelPathCreator = new LevelPathCreator(_levelsConfig);
            return new LevelCreator(
                serviceContainer.Get<ILevelGridBuilder>(), 
                levelParser, 
                levelPathCreator);
        }
    }
}