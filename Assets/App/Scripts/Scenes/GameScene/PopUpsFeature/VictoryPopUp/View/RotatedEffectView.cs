using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.PopUpsFeature.VictoryPopUp.View
{
    public class RotatedEffectView : MonoBehaviour
    {
        [SerializeField] private GameObject _victoryEffetc;
        [SerializeField] private float _rotationSpeed = 3f;
        private Sequence _animation;

        public void StartAnimation()
        {
            _animation = DOTween.Sequence();
            _animation.Append(_victoryEffetc.gameObject.transform
                .DORotate(new Vector3(0, 0, 360), _rotationSpeed, RotateMode.FastBeyond360))
                .SetUpdate(true);
        }

        public void StopAnimation()
        {
            _animation.Kill();
        }
    }
}