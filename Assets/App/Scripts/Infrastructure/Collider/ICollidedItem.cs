namespace App.Scripts.Infrastructure.Collider
{
    public interface ICollidedItem
    {
        void AddModel(ICollidedModel collidedModel);
        void OnCollide();
    }
}