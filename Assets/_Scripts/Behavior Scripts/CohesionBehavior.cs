using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion Behavior")]
public class CohesionBehavior : FlockBehaviour
{
    private Vector2 _cohesionVector;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _cohesionVector = Vector2.zero;
        
        if (context.Count == 0)
            return Vector2.zero;
        
        for (int i = 0; i < context.Count; i++)
            _cohesionVector += (Vector2)context[i].position;

        _cohesionVector /= context.Count;
        
        // calculates offset from current agent's position
        _cohesionVector -= (Vector2)currentAgent.transform.position;

        return _cohesionVector;
    }
}
