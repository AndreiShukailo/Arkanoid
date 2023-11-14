using App.Scripts.Libs.Factory;
using App.Scripts.Libs.Localization;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Scripts.Scenes.PackSelectScene.Features.PacksFeature.View
{
    public class PackFactory : IFactory<PackView, PackViewContext>
    {
        private readonly LocalizationController _localizationController;
        private readonly Transform _container;

        public PackFactory(LocalizationController localizationController, Transform container)
        {
            _localizationController = localizationController;
            _container = container;
        }

        public PackView Create(PackViewContext context)
        {
            var packView = Object.Instantiate(context.PackView, _container);
            packView.Construct(context.Pack, _localizationController, context.LevelCount, context.OnButtonClick);

            return packView;
        }
    }
}