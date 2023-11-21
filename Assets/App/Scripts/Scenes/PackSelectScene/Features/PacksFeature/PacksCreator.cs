using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Infrastructure.PackManagement;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.States;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.Factory;
using App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View;
using App.Scripts.Scenes.PackSelectScene.PackSelectedStates;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature
{
    public class PacksCreator
    {
        private const string LastPackViewKey = "Last";
        private const string ComletedPackKey = "Completed";
        private const string BlockedPackKey = "Blocked";
        private readonly PackController _packController;
        private readonly PackFactory _packFactory;
        private readonly PackViewContainer _packViewContainer;
        private readonly CommandChangeState _commandChangeState;
        private List<ButtonView> _packButtons = new();

        public PacksCreator(PackController packController, PackFactory packFactory, PackViewContainer packViewContainer,
            CommandChangeState commandChangeState)
        {
            _packController = packController;
            _packFactory = packFactory;
            _packViewContainer = packViewContainer;
            _commandChangeState = commandChangeState;
            _packViewContainer.Register();
        }

        public void Cleanup()
        {
            foreach (var packButton in _packButtons)
            {
                if(packButton == null) return;
                packButton.Unsubscribe();
            }
        }

        public void CreatePacks()
        {
            var lastPack = _packController.PlayerProgress.LastPack;
            var completedPacks = _packController.PlayerProgress.CompletedPacks;

            foreach (var pack in _packController.GetAllPacks())
            {
                if (_packController.GetPack(lastPack) == pack && !IsCompleted(completedPacks, pack, out var packInfo1))
                {
                    CreatePack(pack, LastPackViewKey, lastPack.LastLevel - 1, lastPack);
                    continue;
                }

                if (IsCompleted(completedPacks, pack, out var packInfo))
                {
                    CreatePack(pack, ComletedPackKey, pack.LevelsCount, packInfo);
                    continue;
                }

                CreatePack(pack, BlockedPackKey, 0);
            }
        }

        private bool IsCompleted(List<PackInfo> packInfos, Pack pack, out PackInfo packInfo)
        {
            foreach (var item in packInfos.Where(item => _packController.GetPack(item) == pack))
            {
                packInfo = item;
                return true;
            }

            packInfo = null;
            return false;
        }

        private void CreatePack(Pack pack, string packViewKey, int levelsCount, PackInfo packInfo = null)
        {
            var packView = _packFactory.Create(new PackViewContext(
                _packViewContainer.Get(packViewKey),
                pack,
                GetOnButtonClickAction(packInfo),
                levelsCount));
            _packButtons.Add(packView.ButtonView);
        }

        private Action GetOnButtonClickAction(PackInfo packInfo = null)
        {
            if (packInfo == null) return () => { };

            return () =>
            {
                if (!_packController.SetPack(packInfo)) return;
                _commandChangeState.ChangeState<TransitOnGameSceneState>();
            };
        }
    }
}