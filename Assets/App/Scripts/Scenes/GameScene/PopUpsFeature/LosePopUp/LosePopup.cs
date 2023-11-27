using App.Scripts.Infrastructure.Buttons.View;
using App.Scripts.Libs.PopUp.View;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.LosePopUp
{
    public class LosePopup : PopUpView
    {
        public ButtonView ByHealthButtonView => _byHealthButtonView;
        [SerializeField] private ButtonView _byHealthButtonView;
    }
}