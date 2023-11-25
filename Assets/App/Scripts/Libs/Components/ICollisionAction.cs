namespace App.Scripts.Libs.Components
{
    public interface ICollisionAction
    {
        void Collision(CollisionContext collisionContext,  ComponentContainer collidedComponent);
    }
}