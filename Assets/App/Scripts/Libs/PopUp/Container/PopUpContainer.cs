using System.Collections.Generic;
using App.Scripts.Libs.PopUp.Factory;

namespace App.Scripts.Libs.PopUp.Container
{
    public class PopUpContainer
    {
        private Dictionary<string, PopUpFactory> _popupContainer = new ();

        public PopUpFactory GetPopup(string key)
        {
            return _popupContainer[key];
        }

        public void AddPopUp(string key, PopUpFactory popUpFactory)
        {
            _popupContainer[key] = popUpFactory;
        }

        public void RemovePopups(params string[] keys)
        {
            for (int i = 0; i < keys.Length; i++)
                _popupContainer.Remove(keys[i]);
        }
    }
}