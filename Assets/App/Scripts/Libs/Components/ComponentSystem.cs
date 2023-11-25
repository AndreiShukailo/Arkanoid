using System.Collections.Generic;
using App.Scripts.Libs.Systems;

namespace App.Scripts.Libs.Components
{
    public abstract class ComponentSystem<TComponent> : ISystem, ISystemsContainer where TComponent : Component
    {
        protected List<TComponent> _components = new ();

        public virtual void Add(TComponent component)
        {
            _components.Add(component);
        }
        
        public virtual void Remove(TComponent component)
        {
            _components.Remove(component);
        }

        public virtual void OnUpdate(TComponent component)
        {
            
        }

        public virtual void Init()
        {
            
        }

        public virtual void Update(float dt)
        {
            for (var i = _components.Count - 1; i >= 0; i--)
            {
                UpdateComponent(_components[i]);
            }
        }

        public virtual void Cleanup()
        {
            
        }

        public virtual void ClearSystem()
        {
        }

        private void UpdateComponent(TComponent component)
        {
            if (component.IsRemove)
            {
                Remove(component);
                return;
            }
            
            OnUpdate(component);
        }
    }
}