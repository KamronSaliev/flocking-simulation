using FlockingSimulation.Core;
using UnityEngine;
using VContainer;

namespace FlockingSimulation.UI
{
    public class CanvasCameraSetter : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        [Inject]
        public void Construct(CameraHolder cameraHolder)
        {
            _canvas.worldCamera = cameraHolder.Camera;
        }
        
#if UNITY_EDITOR
        
        private void OnValidate()
        {
            if (_canvas == null)
            {
                _canvas = GetComponent<Canvas>();
            }
        }
        
#endif
        
    }
}