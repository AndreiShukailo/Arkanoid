namespace App.Scripts.Infrastructure.Component
{
    public interface IComponent
    {
        ComponentsContainer ComponentsContainer { get; }
        void OnAdd(ComponentsContainer componentsContainer);
        void OnRemove(ComponentsContainer componentsContainer);
    }
}