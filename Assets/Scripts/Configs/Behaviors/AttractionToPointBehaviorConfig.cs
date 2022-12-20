using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/AttractionToPointBehaviorConfig")]
    public class AttractionToPointBehaviorConfig : BehaviorConfig
    {
        /// <summary>
        ///     The transforms of the points to which the agents are attracted
        /// </summary>
        [SerializeField] private Vector2[] _points;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            if (_points.Length == 0)
            {
                return Vector2.zero;
            }

            var pointTowardsVector = GetClosestPoint(currentAgent.transform) - (Vector2)currentAgent.transform.position;
            return pointTowardsVector;
        }

        /// <summary>
        ///     Defines to which destination point the agent should move
        /// </summary>
        /// <param name="currentAgentTransform">The transform of the current agent</param>
        private Vector2 GetClosestPoint(Transform currentAgentTransform)
        {
            // initially the destination point is selected as the first point
            var closestPoint = _points[0];
            var closestPointDistance = Vector2.Distance(currentAgentTransform.position, _points[0]);

            for (var i = 1; i < _points.Length; i++)
            {
                var distanceToPoint = Vector2.Distance(currentAgentTransform.position, _points[i]);
                if (distanceToPoint < closestPointDistance)
                {
                    closestPointDistance = distanceToPoint;
                    closestPoint = _points[i];
                }
            }

            return closestPoint;
        }
    }
}