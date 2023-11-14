using App.Scripts.Infrastructure.Buttons.View;

namespace App.Scripts.Infrastructure.Buttons
{
    public class ButtonManager
    {
        private readonly ButtonsViewContainer _buttonsViewContainer;

        public ButtonManager(ButtonsViewContainer buttonsViewContainer)
        {
            _buttonsViewContainer = buttonsViewContainer;
            _buttonsViewContainer.Register();
        }

        public ButtonView GetButton(string key)
        {
            return _buttonsViewContainer.GetFactory(key).Create();
        }
    }
}