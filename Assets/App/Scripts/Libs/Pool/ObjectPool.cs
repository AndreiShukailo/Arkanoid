using System;
using System.Collections.Generic;

namespace App.Scripts.Libs.Pool
{
    public class ObjectPool<T> : IObjectPool<T>, IObjectPool where T : class
    {
        private readonly Func<T> _spawner;
        private readonly Stack<T> _items = new();
        private int _size;
        
        public int ItemCount => _items.Count;

        protected ObjectPool(Func<T> spawner, int initSize)
        {
            _spawner = spawner;
            Resize(initSize);
        }
        
        protected ObjectPool(Func<T> spawner)
        {
            _spawner = spawner;
        }

        public void Resize(int itemCount)
        {
            var countDifference = itemCount - _size;
            if(countDifference > 0)
                AddElements(countDifference);
        }

        public T Spawn()
        {
            var item = _items.Count > 0 ? _items.Pop() : CreatePullItem();
            OnItemSpawned(item);
            return item;
        }

        public void Despawn(object item)
        {
            if (item is T typeItem)
            {
                _items.Push(typeItem);
                OnDespawnItem(typeItem);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        protected virtual void OnItemSpawned(T item)
        {
        }

        protected virtual void OnDespawnItem(T item)
        {
        }

        protected virtual void OnItemCreated(T item)
        {
        }

        private void AddElements(int countDifference)
        {
            for (var i = 0; i < countDifference; i++)
            {
                _items.Push(CreatePullItem());
            }
        }

        private T CreatePullItem()
        {
            var item = _spawner.Invoke();
            OnItemCreated(item);
            return item;
        }
    }
}