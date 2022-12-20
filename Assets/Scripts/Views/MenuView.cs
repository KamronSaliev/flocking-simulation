using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MenuView : MonoBehaviour
    {
        public Button AlignmentBehaviorButton => _alignmentBehaviorButton;

        public Button AvoidanceBehaviorButton => _avoidanceBehaviorButton;

        public Button AttractionBehaviorButton => _attractionBehaviorButton;

        public Button CohesionBehaviorButton => _cohesionBehaviorButton;

        public Button CompositeBehaviorButton => _compositeBehaviorButton;

        [SerializeField] private Button _alignmentBehaviorButton;

        [SerializeField] private Button _avoidanceBehaviorButton;

        [SerializeField] private Button _attractionBehaviorButton;

        [SerializeField] private Button _cohesionBehaviorButton;

        [SerializeField] private Button _compositeBehaviorButton;
    }
}