using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Centered Behavior")]
public class CenteredBehavior : FlockBehavior
{
    public Vector2 center = Vector2.zero;
    
    /// <summary>
    /// The radius inside which the flock should stay
    /// </summary>
    public float radius = 10f;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        Vector2 centerTowardsVector = center - (Vector2)currentAgent.transform.position;
        return (centerTowardsVector.magnitude > radius ? centerTowardsVector : Vector2.zero);
    }
}
