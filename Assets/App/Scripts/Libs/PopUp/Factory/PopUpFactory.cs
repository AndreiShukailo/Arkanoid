using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Libs.PopUp.Factory
{
    public abstract class PopUpFactory : PoolFactory<PopUpView>
    {
        private LocalizationController _localizationController;

        protected PopUpFactory(PoolSetting<PopUpView> poolSetting) : base(
            poolSetting)
        {
        }

        public void AddLocalization(LocalizationController localizationController)
        {
            _localizationController = localizationController;
        }

        public override PopUpView Create()
        {
            var view = _poolProvider.ObjectPool.Spawn();
            view.SetLocalization(_localizationController);
            return BuildPopup(view, _localizationController);
        }

        protected abstract PopUpView BuildPopup(PopUpView popUpView, LocalizationController localizationController);
    }
}