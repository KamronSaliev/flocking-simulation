using FlockingSimulation.Extensions;
using UnityEngine;

namespace FlockingSimulation.UI
{
    public class SafeAreaResizer : MonoBehaviour
    {
        [SerializeField] private RectTransform _safeArea;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_safeArea == null)
            {
                _safeArea = GetComponent<RectTransform>();
            }
        }
#endif

        private void Awake()
        {
            _safeArea.ResizeBySafeArea();
        }
    }
}