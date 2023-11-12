using System;
using App.Scripts.Infrastructure.Buttons;

namespace App.Scripts.Scenes.StartScene
{
    [Serializable]
    public class KeyButton
    {
        public string Key;
        public ButtonView ButtonView;
    }
}