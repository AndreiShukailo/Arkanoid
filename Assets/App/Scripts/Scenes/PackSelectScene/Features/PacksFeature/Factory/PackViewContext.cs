using System;
using App.Scripts.Infrastructure.LevelsManagement;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View
{
    public class PackViewContext
    {
        public PackView PackView { get; }
        public Pack Pack { get; }
        public Action OnButtonClick { get; }
        public int LevelCount { get; }

        public PackViewContext(PackView packView, Pack pack, Action onButtonClick, int levelCount)
        {
            PackView = packView;
            Pack = pack;
            OnButtonClick = onButtonClick;
            LevelCount = levelCount;
        }
    }
}