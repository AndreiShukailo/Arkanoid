using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Level.View
{
    public class ConfettiEffectView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _topEffect;
        [SerializeField] private ParticleSystem _bottomEffect;
        
        public void Construct(FieldInfo fieldInfo)
        {
            _topEffect.transform.position = new Vector2(0, fieldInfo.CameraBorders.yMax);
            var shape = _topEffect.shape;
            shape.scale =  new Vector3(fieldInfo.CameraBorders.xMax - fieldInfo.CameraBorders.xMin, 0, 0);
            _bottomEffect.transform.position = new Vector2(-3f, fieldInfo.CameraBorders.yMin);
        }

        public void PlayEffect()
        {
            _topEffect.gameObject.SetActive(true);
            _bottomEffect.gameObject.SetActive(true);
        }

        public void StopEffect()
        {
            _topEffect.gameObject.SetActive(false);
            _bottomEffect.gameObject.SetActive(false);
        }
    }
}