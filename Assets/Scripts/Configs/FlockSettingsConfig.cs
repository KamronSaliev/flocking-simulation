using UnityEngine;
using Views;

namespace Configs
{
    [CreateAssetMenu(menuName = "Simulation/FlockSettingsConfig")]
    public class FlockSettingsConfig : ScriptableObject
    {
        public FlockAgentView[] AgentTypes => _agentTypes;

        public int AgentCount => _agentCount;

        public float FlockDensity => _flockDensity;

        public float AgentSpeed => _agentSpeed;

        public float NeighborRadius => _neighborRadius;

        public float AvoidanceRadiusMultiplier => _avoidanceRadiusMultiplier;

        [SerializeField] private FlockAgentView[] _agentTypes;

        [Range(1, 1000)] [SerializeField] private int _agentCount = 100;

        [Range(0.0f, 1.0f)] [SerializeField] private float _flockDensity = 0.1f;

        [Range(1.0f, 100.0f)] [SerializeField] private float _agentSpeed = 1;

        /// <summary>
        ///     The radius of any agent to detect neighbors
        /// </summary>
        [Range(1.0f, 10.0f)] [SerializeField] private float _neighborRadius = 1f;

        /// <summary>
        ///     The neighbor radius factor of any agent to avoid detected neighbors
        /// </summary>
        [Range(0.0f, 1.0f)] [SerializeField] private float _avoidanceRadiusMultiplier = 0.5f;
    }
}