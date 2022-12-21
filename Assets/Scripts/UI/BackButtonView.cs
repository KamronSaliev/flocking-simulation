using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BackButtonView : MonoBehaviour
    {
        public Button BackButton => _backButton;

        [SerializeField] private Button _backButton;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_backButton == null)
            {
                _backButton = GetComponent<Button>();
            }
        }
#endif
    }
}