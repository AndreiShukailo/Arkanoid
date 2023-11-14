using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Infrastructure.Buttons.View
{
    public abstract class ButtonAnimationBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        protected abstract void OnButtonDown();
        protected abstract void OnButtonUp();

        public void OnPointerDown(PointerEventData eventData) =>
            OnButtonDown();

        public void OnPointerUp(PointerEventData eventData) =>
            OnButtonUp();
    }
}