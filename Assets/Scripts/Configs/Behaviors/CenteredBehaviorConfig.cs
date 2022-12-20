using System.Collections.Generic;
using Core;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    [CreateAssetMenu(menuName = "Simulation/Behaviors/CenteredBehaviorConfig")]
    public class CenteredBehaviorConfig : BehaviorConfig
    {
        /// <summary>
        ///     The radius inside which the flock should stay
        /// </summary>
        [SerializeField] private float _radius = 20.0f;

        [SerializeField] private Vector2 _center = Vector2.zero;

        public override Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig)
        {
            var centerTowardsVector = _center - (Vector2)currentAgent.transform.position;
            return centerTowardsVector.magnitude > _radius ? centerTowardsVector : Vector2.zero;
        }
    }
}