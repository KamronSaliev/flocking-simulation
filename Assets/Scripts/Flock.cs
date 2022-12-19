using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] private FlockAgent[] agentTypes;

    [Range(1, 1000)] [SerializeField] private int agentCount = 100;

    [Range(0.0f, 1f)] [SerializeField] private float flockDensity = 0.1f;

    [SerializeField] private FlockBehavior flockBehaviour;

    [Range(1.0f, 100.0f)] [SerializeField] private float agentSpeed = 1;

    /// <summary>
    ///     The radius of any agent to detect neighbors
    /// </summary>
    [Range(1.0f, 10.0f)] [SerializeField] private float neighborRadius = 1f;

    /// <summary>
    ///     The neighbor radius factor of any agent to avoid detected neighbors
    /// </summary>
    [Range(0.0f, 1.0f)] [SerializeField] private float avoidanceRadiusMultiplier = 0.5f;

    /// <summary>
    ///     The avoidance radius
    /// </summary>
    public float AvoidanceRadius { get; private set; }

    private readonly List<FlockAgent> _agents = new List<FlockAgent>();

    private void Start()
    {
        flockBehaviour = BehaviorManager.currentBehaviorType.BehaviorObject;

        AvoidanceRadius = neighborRadius * avoidanceRadiusMultiplier;

        for (var i = 0; i < agentCount; i++)
        {
            var typeIndex = GetRandomAgentType();

            var newAgent = CreateNewAgent(typeIndex);

            NameAgent(newAgent, typeIndex, i);

            newAgent.BelongsToFlock(typeIndex);

            _agents.Add(newAgent);
        }
    }

    private void Update()
    {
        if (flockBehaviour == null)
        {
            return;
        }

        foreach (var agent in _agents)
        {
            var context = GetNeighborObjects(agent);

            var agentVelocity = flockBehaviour.CalculateMove(agent, context, this);
            agentVelocity = agentVelocity.normalized * agentSpeed;

            agent.Move(agentVelocity);
        }
    }

    private int GetRandomAgentType()
    {
        var typeIndex = Random.Range(0, agentTypes.Length);
        return typeIndex;
    }

    /// <summary>
    ///     Detects all neighbors of the selected agent
    /// </summary>
    /// <param name="agent">The selected agent</param>
    private List<Transform> GetNeighborObjects(FlockAgent agent)
    {
        var context = new List<Transform>();
        var neighborColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        for (var i = 0; i < neighborColliders.Length; i++)
        {
            if (agent.AgentCollider == neighborColliders[i])
            {
                continue;
            }

            context.Add(neighborColliders[i].transform);
        }

        return context;
    }

    private FlockAgent CreateNewAgent(int type)
    {
        var newAgent = Instantiate(
            agentTypes[type],
            flockDensity * agentCount * Random.insideUnitCircle,
            Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
            transform);

        return newAgent;
    }

    private void NameAgent(FlockAgent agent, int type, int index)
    {
        agent.name = Constants.FlockAgentPrefix + Constants.FlockName + type + "_" + index;
    }
}