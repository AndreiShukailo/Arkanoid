using App.Scripts.Infrastructure.Component;
using App.Scripts.Scenes.GameScene.Ball.Systems;
using UnityEngine;
using Component = App.Scripts.Infrastructure.Component.Component;

namespace App.Scripts.Scenes.GameScene.Ball.Components
{
    public class CheckCameraBordersComponent : Component, ICheckCameraBordersComponent
    {
        public Rect ItemRect => _physicalComponent.GetRectCollider();
        
        private readonly CheckCameraBordersSystem _checkCameraBordersSystem;
        private readonly IPhysicalComponent _physicalComponent;

        public CheckCameraBordersComponent(IPhysicalComponent physicalComponent, CheckCameraBordersSystem checkCameraBordersSystem)
        {
            _physicalComponent = physicalComponent;
            _checkCameraBordersSystem = checkCameraBordersSystem;
        }

        public override void OnAdd(ComponentsContainer componentsContainer)
        {
            base.OnAdd(componentsContainer);
            _checkCameraBordersSystem.AddComponent(this);
        }

        public override void OnRemove(ComponentsContainer componentsContainer)
        {
            base.OnRemove(componentsContainer);
            _checkCameraBordersSystem.RemoveComponent(this);
        }

        public void OnBordersCollide(Vector2 normal)
        {
            _physicalComponent.Reflect(normal);
        }

        public void OnCameraInvisible()
        {
            
        }
    }
}