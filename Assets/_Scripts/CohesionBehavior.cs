using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehaviour
{
    private Vector2 _cohesionVelocity;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector2.zero;
        
        for (int i = 0; i < context.Count; i++)
            _cohesionVelocity += (Vector2)context[i].position;

        _cohesionVelocity /= context.Count;

        return _cohesionVelocity;
    }
}
