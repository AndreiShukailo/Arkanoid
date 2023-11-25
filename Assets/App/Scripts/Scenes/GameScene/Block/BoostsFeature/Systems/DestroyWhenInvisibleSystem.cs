using App.Scripts.Libs.Components;
using App.Scripts.Scenes.GameScene.Block.BoostsFeature.Components;
using App.Scripts.Scenes.GameScene.Level.LevelField.Field;

namespace App.Scripts.Scenes.GameScene.Block.BoostsFeature.Systems
{
    public class DestroyWhenInvisibleSystem : ComponentSystem<DestroyWhenInvisibleComponent>
    {
        private readonly FieldInfo _fieldInfo;

        public DestroyWhenInvisibleSystem(FieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
        }

        public override void OnUpdate(DestroyWhenInvisibleComponent component)
        {
            base.OnUpdate(component);
            if(component.Rect.yMax > _fieldInfo.CameraBorders.yMin) return;
            component.ComponentContainer.AddToSystem<DeathComponent>();
            Remove(component);
        }

        public override void ClearSystem()
        {
            foreach (var component in _components)
                component.ComponentContainer.Remove();
        }
    }
}