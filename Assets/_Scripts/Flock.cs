using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public int agentCount = 100;
    public float flockDensity = 0.1f;

    private string _agentName = "FlockAgent";

    void Start()
    {
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
        }
    }
}