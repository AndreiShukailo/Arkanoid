namespace App.Scripts.Libs.Pool
{
    public interface IObjectPool
    {
        public int ItemCount { get; }
        public void Resize(int itemCount);
        public void Despawn(object item);
        public void Clear();
    }

    public interface IObjectPool<out T>
    {
        T Spawn();
    }
}