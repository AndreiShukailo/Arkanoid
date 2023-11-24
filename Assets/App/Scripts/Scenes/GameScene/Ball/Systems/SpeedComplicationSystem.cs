using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Ball.Components;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Systems
{
    public class SpeedComplicationSystem : ComponentSystem<SpeedComplicationComponent>
    {
        private float _complicationFactor;

        public override void OnUpdate(SpeedComplicationComponent component)
        {
            base.OnUpdate(component);
            if (_complicationFactor == 0) return;
            component.MovingComponent.SetSpeed(Mathf.Lerp(component.MovingComponent.StartSpeed, component.MaxSpeed,
                _complicationFactor));
        }

        public void Complicate(float levelProgress)
        {
            _complicationFactor = levelProgress;
        }
    }
}