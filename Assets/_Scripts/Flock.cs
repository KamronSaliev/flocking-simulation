using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public int agentCount = 100;
    public float flockDensity = 0.1f;
    public float neighborRadius = 1f;

    private List<FlockAgent> _agents;
    private string _agentName = "FlockAgent";

    void Start()
    {
        _agents = new List<FlockAgent>();
        
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
            Collider2D[] neighborColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
            agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, neighborColliders.Length / 10f);
        }
    }
}