using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/SmoothedAlignmentBehaviorConfig")]
    public class SmoothedAlignmentBehaviorConfig : AlignmentBehaviorConfig
    {
        [SerializeField] private float _smoothTime;

        private Vector2 _smoothedAlignmentVector;

        private Vector2 _currentVelocity;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            _smoothedAlignmentVector = base.CalculateMove(currentAgent, context, flockSettingsConfig);

            // gradually changes the vector
            _smoothedAlignmentVector = Vector2.SmoothDamp(currentAgent.transform.up, _smoothedAlignmentVector,
                ref _currentVelocity, _smoothTime);

            return _smoothedAlignmentVector;
        }
    }
}