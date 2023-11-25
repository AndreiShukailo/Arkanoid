using System;
using System.Collections.Generic;
using App.Scripts.Libs.Pool;
using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public class ComponentContainer : SpawnableItemMono
    {
        public string ID => _id;
        [SerializeField] private string _id;
        [SerializeField] private List<Component> _components;

        private Dictionary<Type, Component> _componentsContainer = new();
        private SystemsContainer _systemsContainer;

        public void Register(SystemsContainer systemsContainer)
        {
            _systemsContainer = systemsContainer;

            foreach (var component in _components)
            {
                _componentsContainer[component.GetType()] = component;
                component.Construct(this);
            }
        }

        public void AddToSystem<TComponent>() where TComponent : Component
        {
            var component = Get<TComponent>();
            if(component == null) return;
            component.OnAdd();
            _systemsContainer.GetSystem<TComponent>().Add(component);
        }

        public TComponent Get<TComponent>() where TComponent : Component
        {
            var componentType = typeof(TComponent);
            return _componentsContainer.TryGetValue(componentType, out var component)
                ? (TComponent)component
                : null;
        }

        public override void Remove()
        {
            base.Remove();
            foreach (var component in _componentsContainer.Values)
            {
                component.OnRemove();
            }
            
            _componentsContainer.Clear();
        }
    }

    public class SystemsContainer
    {
        private Dictionary<Type, ISystemsContainer> _systemsContainer = new();

        public void AddSystem<TComponent, TSystem>(TSystem system)
            where TComponent : Component where TSystem : ISystemsContainer
        {
            _systemsContainer[typeof(TComponent)] = system;
        }

        public ComponentSystem<TComponent> GetSystem<TComponent>() where TComponent : Component
        {
            var componentType = typeof(TComponent);
            if (_systemsContainer.TryGetValue(componentType, out var container))
                return container as ComponentSystem<TComponent>;

            return null;
        }

        public void CleanupSystems()
        {
            foreach (var item in _systemsContainer.Values)
                item.ClearSystem();
        }
    }

    public interface ISystemsContainer
    {
        void ClearSystem();
    }
}