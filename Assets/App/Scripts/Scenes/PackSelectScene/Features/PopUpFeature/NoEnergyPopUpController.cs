using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Libs.PopUp;
using App.Scripts.Libs.TaskExtensions;
using App.Scripts.Scenes.StartScene.Language.PopUp;

namespace App.Scripts.Scenes.PackSelectScene.Features.PopUpFeature
{
    public class NoEnergyPopUpController
    {
        private const string ButtonID = "VioletButton";
        private const string ContinueLanguageKey = "Continue";
        private readonly PopUpController _popUpController;
        private readonly ButtonManager _buttonManager;

        public NoEnergyPopUpController(PopUpController popUpController, ButtonManager buttonManager)
        {
            _popUpController = popUpController;
            _buttonManager = buttonManager;
        }

        public void ShowPopUp()
        {
            var popView = _popUpController.Show<NoEnergyPopUp>();
            _buttonManager.BuildButton(popView.Content, Close, ButtonID, ContinueLanguageKey);
            popView.ProcessShow().Forget();
        }
        
        private void Close()
        {
            _popUpController.Hide<NoEnergyPopUp>().Forget();
        }
    }
}