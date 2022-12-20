using System.Collections.Generic;
using Core;
using UnityEngine;
using Views;

namespace Configs.Behaviors
{
    public abstract class BehaviorConfig : ScriptableObject
    {
        /// <summary>
        ///     Calculates the vector of movement for current agent
        /// </summary>
        /// <param name="currentAgent">The current flock agent</param>
        /// <param name="context">The list of transforms of neighbors</param>
        /// <param name="flockSettingsConfig">Settings of the flock simulation</param>
        public abstract Vector2 CalculateMove(FlockAgentView currentAgent, List<Transform> context,
            FlockSettingsConfig flockSettingsConfig);
    }
}