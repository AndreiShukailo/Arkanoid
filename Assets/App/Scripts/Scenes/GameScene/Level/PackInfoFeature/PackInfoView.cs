using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.GameScene.Level.PackInfoFeature
{
    public class PackInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelCount;
        [SerializeField] private Image _levelIcon;
        private PackInfoController _packInfoController;

        public void Construct(PackInfoController packInfoController)
        {
            _packInfoController = packInfoController;
            _packInfoController.OnUpdatePackInfo += UpdatePAckInfo;
        }

        private void UpdatePAckInfo()
        {
            _levelCount.text =
                $"{_packInfoController.CurrentPackInfo.LastLevel - 1}/{_packInfoController.CurrentPack.LevelsCount}";
            _levelIcon.sprite = _packInfoController.CurrentPack.Icon;
        }
    }
}