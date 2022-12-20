using System.Collections.Generic;
using Core;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/CohesionBehaviorConfig")]
    public class CohesionBehaviorConfig : FilteredBehaviorConfig
    {
        private Vector2 _cohesionVector;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            _cohesionVector = Vector2.zero;

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
                _cohesionVector += (Vector2)context[i].position;
            }

            _cohesionVector /= context.Count;

            // calculates offset from current agent's position
            _cohesionVector -= (Vector2)currentAgent.transform.position;

            return _cohesionVector;
        }
    }
}