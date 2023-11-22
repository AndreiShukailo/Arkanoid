using UnityEngine;

namespace App.Scripts.Libs.Components
{
    public abstract class Component : MonoBehaviour
    {
        public ComponentContainer ComponentContainer { get; private set; }
        public bool IsRemove { get; private set; }

        public virtual void Construct(ComponentContainer componentContainer)
        {
            ComponentContainer = componentContainer;
        }

        public virtual void OnRemove()
        {
            IsRemove = true;
        }

        public virtual void OnAdd()
        {
            IsRemove = false;
        }
    }
}