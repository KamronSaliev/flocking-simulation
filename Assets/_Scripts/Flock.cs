using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{ 
    /// <summary>
    /// The prefab of an flock agent to instantiate
    /// </summary>
    [SerializeField] private FlockAgent agentPrefab;
    
    /// <summary>
    /// The number of agents to instantiate
    /// </summary>
    [Range(50, 300)]
    [SerializeField] private int agentCount = 100;
    
    /// <summary>
    /// The flock density before instantiation of the agents
    /// </summary>
    [Range(0.0f, 1f)]
    [SerializeField] private float flockDensity = 0.1f;
    
    /// <summary>
    /// The behavior of the flock
    /// </summary>
    [SerializeField] private FlockBehaviour flockBehaviour;
    
    /// <summary>
    /// The speed multiplier of any agent
    /// </summary>
    [Range(1.0f, 10.0f)]
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
        _avoidanceRadius = neighborRadius * avoidanceRadiusMultiplier;
        
        if (agentPrefab == null)
            return;

        for (int i = 0; i < agentCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                flockDensity * agentCount * Random.insideUnitCircle,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);
            
            newAgent.name = Constants.FlockAgentName + i;
            newAgent.BelongsToFlock(this);

            _agents.Add(newAgent);
        }
    }

    private void Update()
    {
        foreach (FlockAgent agent in _agents)
        {
            List<Transform>context = GetNeighborObjects(agent);
            
            Vector2 agentVelocity = flockBehaviour.CalculateMove(agent, context, this);
            agentVelocity *= agentSpeed;
            
            agent.Move(agentVelocity);
        }
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