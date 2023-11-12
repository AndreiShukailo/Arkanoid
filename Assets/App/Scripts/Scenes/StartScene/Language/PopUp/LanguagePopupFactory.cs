using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Scenes.StartScene.Language.PopUp
{
    public class LanguagePopupFactory : PopUpFactory
    {
        public LanguagePopupFactory(PoolSetting<PopUpView> poolSetting) :
            base(poolSetting)
        {
        }
        
        
        protected override PopUpView BuildPopup(PopUpView popUpView, LocalizationController localizationController)
        {
            return popUpView;
        }
    }
}