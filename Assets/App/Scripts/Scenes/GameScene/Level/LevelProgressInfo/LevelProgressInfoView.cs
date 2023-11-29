using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.GameScene.Level.LevelProgressInfo
{
    public class LevelProgressInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelCount;
        [SerializeField] private TMP_Text _levelProgress;
        [SerializeField] private Image _levelIcon;
        private LevelProgressInfoController _levelProgressInfoController;

        public void Construct(LevelProgressInfoController levelProgressInfoController)
        {
            _levelProgressInfoController = levelProgressInfoController;
            _levelProgressInfoController.OnUpdatePackInfo += UpdatePackInfo;
            _levelProgressInfoController.OnUpdateLevelProgress += UpdateLevelProgressInfo;
        }

        private void UpdatePackInfo()
        {
            _levelCount.text =
                $"{_levelProgressInfoController.CurrentPackInfo.LastLevel - 1}/{_levelProgressInfoController.CurrentPack.LevelsCount}";
            _levelIcon.sprite = _levelProgressInfoController.CurrentPack.Icon;
            _levelIcon.color = Color.white;
        }

        private void UpdateLevelProgressInfo()
        {
            _levelProgress.text = $"{(int)(_levelProgressInfoController.CurrentLevelProgress * 100)}%";
        }
    }
}