using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.GameScene.HudFeature.HealthBar
{
    public class HealthItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _active;
        [SerializeField] private Sprite _deactive;

        public void SetActive(bool isActive)
        {
            _image.sprite = isActive ? _active : _deactive;
        }
    }
}