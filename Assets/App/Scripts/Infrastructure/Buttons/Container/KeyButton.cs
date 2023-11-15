using System;
using App.Scripts.Infrastructure.Buttons.View;

namespace App.Scripts.Infrastructure.Buttons.Container
{
    [Serializable]
    public class KeyButton
    {
        public string Key;
        public ButtonView ButtonView;
    }
}