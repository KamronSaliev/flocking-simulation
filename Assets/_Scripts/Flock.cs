using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public int agentCount = 100;
    public FlockBehaviour flockBehaviour;
    public float flockMaxSpeed = 1f;
    public float flockDensity = 0.1f;
    public float neighborRadius = 1f;
    public float avoidanceRadiusMultiplier = 0.5f;

    private float _avoidanceRadius;
    public float AvoidanceRadius
    {
        get => _avoidanceRadius;
    }

    private List<FlockAgent> _agents;
    private string _agentName = "FlockAgent";

    void Start()
    {
        _agents = new List<FlockAgent>();
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
            newAgent.name = _agentName + "_" + i;
            
            _agents.Add(newAgent);
        }
    }

    private void Update()
    {
        foreach (FlockAgent agent in _agents)
        {
            List<Transform>context = GetNeighborObjects(agent);
            
            agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, context.Count / 10f);

            Vector2 agentVelocity = flockBehaviour.CalculateMove(agent, context, this);
            Vector2.ClampMagnitude(agentVelocity, flockMaxSpeed);
            
            Debug.Log(agentVelocity);
            
            agent.Move(agentVelocity);
        }
    }

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