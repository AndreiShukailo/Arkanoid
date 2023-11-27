using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.PopUp.View;
using UnityEngine;

namespace App.Scripts.Scenes.StartScene.Language.PopUp
{
    public class LanguagePopUp : PopUpView
    {
        public ButtonView CloseLocalizationPopUp => _closeLocalizationPopUp;
        [SerializeField] private ButtonView _closeLocalizationPopUp;
    }
}