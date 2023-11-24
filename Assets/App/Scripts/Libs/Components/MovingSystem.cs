using System;

namespace App.Scripts.Libs.Components
{
    public class MovingSystem : ComponentSystem<MovingComponent>
    {
        public override void OnUpdate(MovingComponent component)
        {
            base.OnUpdate(component);
            CorrectSpeed(component);
        }

        private void CorrectSpeed(MovingComponent component)
        {
            if(Math.Abs(component.Rigidbody2D.velocity.magnitude - component.CurrentSpeed) > 0f)
                component.Rigidbody2D.velocity = component.Rigidbody2D.velocity.normalized * component.CurrentSpeed;
        }
    }
}