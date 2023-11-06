namespace App.Scripts.Infrastructure.Component
{
    public class Component : IComponent
    {
        public ComponentsContainer ComponentsContainer { get; protected set; }
        public virtual void OnAdd(ComponentsContainer componentsContainer)
        {
            ComponentsContainer = componentsContainer;
        }

        public virtual void OnRemove(ComponentsContainer componentsContainer)
        {
            ComponentsContainer = null;
        }
    }
}