using System;
using System.Collections.Generic;
using App.Scripts.Libs.Localization;
using App.Scripts.Libs.Pool;
using App.Scripts.Libs.PopUp.Factory;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Libs.PopUp.Container
{
    public class PopUpContainer
    {
        private readonly LocalizationController _localizationController;
        private Dictionary<Type, PopUpFactory> _popupContainer = new ();

        public PopUpContainer(LocalizationController localizationController)
        {
            _localizationController = localizationController;
        }

        public PopUpFactory GetPopup<TPopupView>() where TPopupView : PopUpView =>
            _popupContainer[typeof(TPopupView)];

        public void AddPopUp<TPopupView>(PoolSetting<PopUpView> popupPoolSetting) where TPopupView : PopUpView =>
            _popupContainer[typeof(TPopupView)] = new PopUpFactory(popupPoolSetting, _localizationController);

        public void RemovePopups() =>
            _popupContainer.Clear();
    }
}