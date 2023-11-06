using System.Collections.Generic;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.GameScene.Ball.Components;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;
using UnityEngine;

namespace App.Scripts.Scenes.GameScene.Ball.Systems
{
    public class CheckCameraBordersSystem : ISystem
    {
        private readonly FieldInfo _fieldInfo;
        private List<ICheckCameraBordersComponent> _checkComponent;

        public CheckCameraBordersSystem(FieldInfo fieldInfo)
        {
            _checkComponent = new List<ICheckCameraBordersComponent>();
            _fieldInfo = fieldInfo;
        }

        public void AddComponent(ICheckCameraBordersComponent component)
        {
            _checkComponent.Add(component);
        }

        public void RemoveComponent(ICheckCameraBordersComponent component)
        {
            _checkComponent.Remove(component);
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            for (var i = _checkComponent.Count - 1; i >= 0; i--)
                CheckOnBorderCollide(_checkComponent[i]);
        }
        
        public void Cleanup()
        {
            _checkComponent.Clear();
        }

        private void CheckOnBorderCollide(ICheckCameraBordersComponent component)
        {
            // var itemRect = component.ItemRect;
            // var cameraRect = _fieldInfo.CameraBorders;
            // if(itemRect.yMax >= cameraRect.yMax)
            //     component.OnBordersCollide(Vector2.up);
            // if(itemRect.xMax >= cameraRect.xMax)
            //     component.OnBordersCollide(Vector2.right);
            // if (itemRect.xMin <= cameraRect.xMin)
            //     component.OnBordersCollide(Vector2.left);
            // if (itemRect.yMax <= cameraRect.yMin)
            //     component.OnCameraInvisible();
        }
    }
}