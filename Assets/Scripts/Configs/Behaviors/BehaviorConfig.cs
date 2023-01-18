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
        /// <param name="flockSettingsConfig">Settings of the flock simulation</param>
        public abstract Vector2 CalculateMove(FlockAgentView currentAgent, FlockSettingsConfig flockSettingsConfig);
    }
}