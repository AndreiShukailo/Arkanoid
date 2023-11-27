using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Libs.PopUp.Container;
using App.Scripts.Libs.PopUp.View;

namespace App.Scripts.Libs.PopUp
{
    public class PopUpController
    {
        private readonly PopUpContainer _popUpContainer;
        private readonly Dictionary<Type, PopUpView> _openedPopUps = new ();
        private bool _isBlockedUI;
        
        public PopUpController(PopUpContainer popUpContainer)
        {
            _popUpContainer = popUpContainer;
        }

        public TPopUpView Show<TPopUpView>() where TPopUpView : PopUpView
        {
            var factory = _popUpContainer.GetPopup<TPopUpView>();
            var popup = factory.Create();
            _openedPopUps.Add(typeof(TPopUpView), popup);
            popup.transform.SetSiblingIndex(_openedPopUps.Count - 1);
            
            return popup as TPopUpView;
        }

        public async Task Hide<TPopUpView>() where TPopUpView : PopUpView
        {
            var popUpType = typeof(TPopUpView);
            await _openedPopUps[popUpType].ProcessHide();
            _openedPopUps.Remove(popUpType);
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
            await Task.WhenAll(tasks);
            _popUpContainer.RemovePopups();
        }
    }
}