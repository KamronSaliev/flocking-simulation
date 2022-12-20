using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/SmoothedCohesionBehaviorConfig")]
    public class SmoothedCohesionBehaviorConfig : CohesionBehaviorConfig
    {
        [SerializeField] private float _smoothTime = 0.5f;

        private Vector2 _smoothedCohesionVector;

        private Vector2 _currentVelocity;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            _smoothedCohesionVector = base.CalculateMove(currentAgent, context, flockSettingsConfig);

            // gradually changes the vector
            _smoothedCohesionVector = Vector2.SmoothDamp(currentAgent.transform.up, _smoothedCohesionVector,
                ref _currentVelocity, _smoothTime);

            return _smoothedCohesionVector;
        }
    }
}