using System.ComponentModel;

namespace App.Scripts.Libs.Pool
{
    public class PoolKeyComponent<T> where T : Component, ISpawnableItem
    {
        public string Key;
        public T View;
    }
}