namespace App.Scripts.Libs.Components
{
    public class HealthSystem : ComponentSystem<HealthComponent>
    {
        public override void OnUpdate(HealthComponent component)
        {
            base.OnUpdate(component);
            component.CurrentHealth -= 1;
            Remove(component);
            if (component.CurrentHealth <= 0)
                component.ComponentContainer.AddToSystem<DeathComponent>();
        }
    }
}