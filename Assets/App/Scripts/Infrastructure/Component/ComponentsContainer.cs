using System;
using System.Collections.Generic;

namespace App.Scripts.Infrastructure.Component
{
    public class ComponentsContainer
    {
        public ItemView ItemView => _itemView;
        
        private readonly ItemView _itemView;
        private Dictionary<Type, IComponent> _components;

        public ComponentsContainer(ItemView itemView)
        {
            _itemView = itemView;
            _components = new Dictionary<Type, IComponent>();
        }

        public void AddComponent<TComponent>(TComponent component) where TComponent : IComponent
        {
            _components[typeof(TComponent)] = component;
            component.OnAdd(this);
        }

        public IComponent GetComponent<TComponent>() where TComponent : IComponent
        {
            return _components.TryGetValue(typeof(TComponent), out var component)
                ? component
                : null;
        }

        public void RemoveComponent<TComponent>() where TComponent : IComponent
        {
            if(_components.TryGetValue(typeof(TComponent), out var component))
                component.OnRemove(this);
        }

        public void RemoveItem()
        {
            _itemView.Remove();
            foreach (var component in _components)
            {
                component.Value.OnRemove(this);
            }

            _components = null;
        }
    }
}