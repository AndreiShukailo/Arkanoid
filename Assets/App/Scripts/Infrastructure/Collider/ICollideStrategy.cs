namespace App.Scripts.Infrastructure.Collider
{
    public interface ICollideStrategy<in T> where T : ICollidedModel
    {
        void OnAddStrategy(T model);
        void OnCollide();
    }
}