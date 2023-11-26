using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.PopUp.View;
using UnityEngine;

namespace App.Scripts.Libs.PopUp
{
    public class PopUpController
    {
        private readonly PopUpContainer _popUpContainer;
        private readonly Dictionary<Type, PopUpView> _openedPopUps = new ();
        private RectTransform _popupParent;
        private bool _isBlockedUI;
        
        public PopUpController(PopUpContainer popUpContainer)
        {
            _popUpContainer = popUpContainer;
        }

        public void BlockUI(bool isBlocked)
        {
            _isBlockedUI = isBlocked;
        }

        public TPopUpView Show<TPopUpView>() where TPopUpView : PopUpView
        {
            var factory = _popUpContainer.GetPopup<TPopUpView>();
            var popup = factory.Create();
            _openedPopUps.Add(typeof(TPopUpView), popup);
            if (_popupParent == null)
                _popupParent = popup.Container;
            
            return popup as TPopUpView;
        }

        public async Task Hide<TPopUpView>() where TPopUpView : PopUpView
        {
            var popUpType = typeof(TPopUpView);
            await _openedPopUps[popUpType].ProcessHide();
            _openedPopUps.Remove(popUpType);
            if (_isBlockedUI && _popupParent != null)
                _popupParent.gameObject.SetActive(true);
        }

        public async Task HideAllPopups()
        {
            var tasks = new Task[_openedPopUps.Count];
            var counter = 0;
            foreach (var popup in _openedPopUps.Values)
            {
                tasks[counter] = popup.ProcessHide();
                counter++;
            }
            
            _openedPopUps.Clear();
            _popupParent = null;
            await Task.WhenAll(tasks);
            _popUpContainer.RemovePopups();
        }
    }
}