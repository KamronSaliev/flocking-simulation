using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Centered Behavior")]
public class CenteredBehavior : FlockBehaviour
{
    public Vector2 center = Vector2.zero;
    public float radius = 10f;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        Vector2 centerOffset = center - (Vector2)currentAgent.transform.position;
        return (centerOffset.magnitude > radius ? centerOffset : Vector2.zero);
    }
}
