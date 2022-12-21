using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/AlignmentBehaviorConfig")]
    public class AlignmentBehaviorConfig : FilteredBehaviorConfig
    {
        /// <summary>
        ///     The vector to align with vectors
        /// </summary>
        private Vector2 _alignmentVector;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, FlockSettingsConfig flockSettingsConfig)
        {
            var context = currentAgent.GetNeighborObjects();
            
            _alignmentVector = Vector2.zero;

            if (context.Count == 0)
            {
                return currentAgent.transform.up;
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
                _alignmentVector += (Vector2)context[i].up;
            }

            _alignmentVector /= context.Count;

            return _alignmentVector;
        }
    }
}