using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.LevelsManagement;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad.SaveLoadService;
using App.Scripts.Infrastructure.SceneManagement;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature
{
    public class PacksCreator
    {
        private readonly PackController _packController;
        private readonly PackFactory _packFactory;
        private readonly PackViewContainer _packViewContainer;
        private readonly SceneLoaderController _sceneLoaderController;

        public PacksCreator(PackController packController, PackFactory packFactory, PackViewContainer packViewContainer,
            SceneLoaderController sceneLoaderController)
        {
            _packController = packController;
            _packFactory = packFactory;
            _packViewContainer = packViewContainer;
            _sceneLoaderController = sceneLoaderController;
            _packViewContainer.Register();
        }

        public void CreatePacks()
        {
            var lastPack = _packController.PlayerProgress.LastPack;
            var completedPacks = _packController.PlayerProgress.CompletedPacks;

            foreach (var pack in _packController.GetAllPacks())
            {
                if (_packController.GetPack(lastPack.PackId) == pack)
                {
                    CreatePack(pack, "Last", lastPack.LastLevel - 1, lastPack);
                    continue;
                }

                if (IsCompleted(completedPacks, pack, out var packInfo))
                {
                    CreatePack(pack, "Completed", packInfo.LastLevel - 1, packInfo);
                    continue;
                }

                CreatePack(pack, "Blocked", 0);
            }
        }

        private bool IsCompleted(List<PackInfo> packInfos, Pack pack, out PackInfo packInfo)
        {
            foreach (var item in packInfos.Where(item => _packController.GetPack(item.PackId) == pack))
            {
                packInfo = item;
                return true;
            }

            packInfo = null;
            return false;
        }

        private void CreatePack(Pack pack, string packViewKey, int levelsCount, PackInfo packInfo = null)
        {
            _packFactory.Create(new PackViewContext(
                _packViewContainer.Get(packViewKey),
                pack,
                GetOnButtonClickAction(pack, packInfo),
                levelsCount));
        }

        private Action GetOnButtonClickAction(Pack pack, PackInfo packInfo = null)
        {
            if (packInfo == null) return () => { };

            return () =>
            {
                _packController.SetPack(packInfo);
                _sceneLoaderController.SetNextScene(_sceneLoaderController.ScenesConfig.GameScene);
            };
        }
    }
}