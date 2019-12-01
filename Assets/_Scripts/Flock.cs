using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{ 
    /// <summary>
    /// The prefab of an flock agent to instantiate
    /// </summary>
    [SerializeField] private FlockAgent[] agentTypes;
    
    /// <summary>
    /// The number of agents to instantiate
    /// </summary>
    [Range(1, 1000)]
    [SerializeField] private int agentCount = 100;
    
    /// <summary>
    /// The flock density before instantiation of the agents
    /// </summary>
    [Range(0.0f, 1f)]
    [SerializeField] private float flockDensity = 0.1f;
    
    /// <summary>
    /// The behavior of the flock
    /// </summary>
    [SerializeField] private FlockBehavior flockBehaviour;
    
    /// <summary>
    /// The speed multiplier of any agent
    /// </summary>
    [Range(1.0f, 100.0f)]
    [SerializeField] private float agentSpeed = 1;
    
    /// <summary>
    /// The radius of any agent to detect neighbors
    /// </summary>
    [Range(1.0f, 10.0f)]
    [SerializeField] private float neighborRadius = 1f;
    
    /// <summary>
    /// The neighbor radius factor of any agent to avoid detected neighbors
    /// </summary>
    [Range(0.0f, 1.0f)]
    [SerializeField] private float avoidanceRadiusMultiplier = 0.5f;
    
    /// <summary>
    /// The avoidance radius
    /// </summary>
    private float _avoidanceRadius;
    public float AvoidanceRadius { get => _avoidanceRadius; }

    private List<FlockAgent> _agents = new List<FlockAgent>();

    void Start()
    {
        flockBehaviour = BehaviorManager.currentBehaviorType.BehaviorObject;
        
        _avoidanceRadius = neighborRadius * avoidanceRadiusMultiplier;

        for (int i = 0; i < agentCount; i++)
        {
            int typeIndex = GetRandomAgentType();

            FlockAgent newAgent = Instantiate(
                agentTypes[typeIndex],
                flockDensity * agentCount * Random.insideUnitCircle,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);
            
            newAgent.name = Constants.FlockAgentPrefix + Constants.FlockName + typeIndex + "_" + i;
            newAgent.BelongsToFlock(typeIndex);

            _agents.Add(newAgent);
        }
    }

    private void Update()
    {
        if (flockBehaviour == null)
            return;            
        
        foreach (FlockAgent agent in _agents)
        {
            List<Transform> context = GetNeighborObjects(agent);
            
            Vector2 agentVelocity = flockBehaviour.CalculateMove(agent, context, this);
            
            agentVelocity = agentVelocity.normalized * agentSpeed;

            agent.Move(agentVelocity);
        }
    }

    private int GetRandomAgentType()
    {
        int typeIndex = Random.Range(0, agentTypes.Length);
        return typeIndex;
    }
    
    /// <summary>
    /// Detects all neighbors of the selected agent
    /// </summary>
    /// <param name="agent">The selected agent</param>
    private List<Transform> GetNeighborObjects(FlockAgent agent)
    {
        List<Transform>context = new List<Transform>();
        Collider2D[] neighborColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        for (int i = 0; i < neighborColliders.Length; i++)
        {
            if (agent.AgentCollider == neighborColliders[i])
                continue;
                
            context.Add(neighborColliders[i].transform);
        }

        return context;
    }
}