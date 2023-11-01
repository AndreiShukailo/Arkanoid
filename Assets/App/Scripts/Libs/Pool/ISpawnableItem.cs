namespace App.Scripts.Libs.Pool
{
    public interface ISpawnableItem
    {
        public void OnCreated(IObjectPool objectPool);
        public void OnSpawned();
        public void OnDespawned();
        public void OnRemoved();
    }
}