using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace FlockingSimulation.Views
{
    [RequireComponent(typeof(Collider2D))]
    public class ButtonView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent PointerClicked;
        public UnityEvent PointerDown;
        public UnityEvent PointerUp;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClicked?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            PointerUp?.Invoke();
        }
    }
}