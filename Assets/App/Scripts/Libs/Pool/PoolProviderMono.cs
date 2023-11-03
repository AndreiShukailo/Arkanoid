using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Scripts.Libs.Pool
{
    public class PoolProviderMono<T> where T : SpawnableItemMono
    {
        public readonly ObjectPoolMono<T> ObjectPool;

        public PoolProviderMono(PoolSetting<T> poolSetting)
        {
            ObjectPool = CreatePool(poolSetting);
        }

        private ObjectPoolMono<T> CreatePool(PoolSetting<T> poolSetting)
        {
            var spawner = new Func<T>(() => Object.Instantiate(poolSetting.SpawnableItemMono, poolSetting.Container));
            return new ObjectPoolMono<T>(spawner, poolSetting.StartSize);
        }
    }

    public class PoolSetting<T> where T : SpawnableItemMono
    {
        public T SpawnableItemMono;
        public Transform Container;
        public int StartSize;
    }
}