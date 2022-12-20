using System.Collections.Generic;
using Core;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/CompositeBehaviorConfig")]
    public class CompositeBehaviorConfig : BehaviorConfig
    {
        /// <summary>
        ///     Single core behaviors with their weights of impact on flock behavior
        /// </summary>
        [SerializeField] private CompositeBehaviorItem[] _behaviors;

        /// <summary>
        ///     The resulting vector of movement, calculated using the weights of each core behavior
        /// </summary>
        private Vector2 _compositeVelocityVector;

        /// <summary>
        ///     The sum of weights of behaviors
        /// </summary>
        private float _weightsSum;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            _compositeVelocityVector = Vector2.zero;
            _weightsSum = 0;

            if (_behaviors.Length == 0)
            {
                return Vector2.zero;
            }

            for (var i = 0; i < _behaviors.Length; i++)
            {
                _weightsSum += _behaviors[i].Weight;
            }

            for (var i = 0; i < _behaviors.Length; i++)
            {
                var movementVector = _behaviors[i].BehaviorConfig
                    .CalculateMove(currentAgent, context, flockSettingsConfig);

                // every behavior vector is multiplied by the ratio of its weight to the sum all weights
                movementVector *= _behaviors[i].Weight / _weightsSum;
                _compositeVelocityVector += movementVector;
            }

            return _compositeVelocityVector;
        }
    }
}