using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Libs.PopUp.Factory
{
    public class PopUpFactory : PoolFactory<PopUpView>
    {
        private LocalizationController _localizationController;

        public PopUpFactory(PoolSetting<PopUpView> poolSetting, LocalizationController localizationController) : base(
            poolSetting)
        {
            _localizationController = localizationController;
        }

        public override PopUpView Create()
        {
            var view = _poolProvider.ObjectPool.Spawn();
            view.SetLocalization(_localizationController);

            return view;
        }
    }
}