using UnityEngine.UI;

namespace App.Scripts.Infrastructure.UIMenegement
{
    public class BlockUIController
    {
        private readonly GraphicRaycaster _blockedUI;

        public BlockUIController(GraphicRaycaster blockedUI)
        {
            _blockedUI = blockedUI;
        }

        public void SetBlocked(bool isBlocked)
        {
            _blockedUI.enabled = !isBlocked;
        }
    }
}