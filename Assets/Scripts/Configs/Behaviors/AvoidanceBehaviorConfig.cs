using System.Collections.Generic;
using Core;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/AvoidanceBehaviorConfig")]
    public class AvoidanceBehaviorConfig : FilteredBehaviorConfig
    {
        /// <summary>
        ///     The vector to avoid neighbors
        /// </summary>
        private Vector2 _avoidanceVector;

        /// <summary>
        ///     The number of neighbors to avoid
        /// </summary>
        private int _avoidObjectsCount;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            _avoidanceVector = Vector2.zero;
            _avoidObjectsCount = 0;

            if (context.Count == 0)
            {
                return Vector2.zero;
            }

            // Filtering the context
            for (var i = 0; i < _filters.Length; i++)
            {
                if (_filters[i] != null)
                {
                    context = _filters[i].GetFilteredContext(currentAgent, context);
                }
            }

            for (var i = 0; i < context.Count; i++)
            {
                var avoidanceRadius =
                    flockSettingsConfig.NeighborRadius * flockSettingsConfig.AvoidanceRadiusMultiplier;

                // if a neighbor is inside avoidance radius, then agent is to avoid the neighbor
                if (Vector2.Distance(currentAgent.transform.position, context[i].position) < avoidanceRadius)
                {
                    _avoidObjectsCount++;
                    _avoidanceVector += (Vector2)(currentAgent.transform.position - context[i].position);
                }
            }

            if (_avoidObjectsCount > 0)
            {
                _avoidanceVector /= _avoidObjectsCount;
            }

            return _avoidanceVector;
        }
    }
}