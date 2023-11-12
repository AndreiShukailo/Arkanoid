using App.Scripts.Libs.AssetProvider;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.TiledParser.TileSet;
using App.Scripts.Scenes.GameScene.Block;
using App.Scripts.Scenes.GameScene.Block.Container;
using App.Scripts.Scenes.GameScene.Block.IronBlocks;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks;
using App.Scripts.Scenes.GameScene.Block.SimleBlocks.Cracks;
using App.Scripts.Scenes.GameScene.Level.Level.Config;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Installers
{
    public class BlocksCreatorInstaller : MonoInstaller
    {
        [SerializeField] private BlocksContainer _blocksContainer;
        [SerializeField] private TileSetConfig _tileSetConfig;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var registeredContainer = RegisterBlocks(serviceContainer);
            serviceContainer.SetService<IBlockCreator, BlockCreator>(CreateBlockCreator(serviceContainer,
                registeredContainer));
        }

        private BlockCreator CreateBlockCreator(ServiceContainer serviceContainer, BlocksContainer blocksContainer)
        {
            var tileSetProvider = new TileSetProvider(serviceContainer.Get<TextDataProvider>());
            var blockCreator = new BlockCreator(blocksContainer, tileSetProvider, _tileSetConfig);

            return blockCreator;
        }

        private BlocksContainer RegisterBlocks(ServiceContainer serviceContainer)
        {
            _blocksContainer.RegisterGroup<SimpleBlockSettings>("Simple",
                setting => new SimpleBlockCollideStrategy(serviceContainer.Get<ICrackCreator>(), setting));
            _blocksContainer.RegisterGroup<IronBlockSetting>("Iron",
                _ => new IronCollideStrategy());
            return _blocksContainer;
        }
    }
}