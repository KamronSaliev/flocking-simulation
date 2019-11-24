using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance Behavior")]
public class AvoidanceBehavior : FlockBehaviour
{
    /// <summary>
    /// The vector to avoid neighbors
    /// </summary>
    private Vector2 _avoidanceVector;
    
    /// <summary>
    /// The number of neighbors to avoid
    /// </summary>
    private int _avoidObjectsCount;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _avoidanceVector = Vector2.zero;
        _avoidObjectsCount = 0;
        
        if (context.Count == 0)
            return Vector2.zero;
            
        for (int i = 0; i < context.Count; i++)
        {
            // if a neighbor is inside avoidance radius, then agent is to avoid the neighbor
            if (Vector2.Distance(currentAgent.transform.position, context[i].position) < flock.AvoidanceRadius)
            {
                _avoidObjectsCount++;
                _avoidanceVector += (Vector2)(currentAgent.transform.position - context[i].position);
            }
        }

        if (_avoidObjectsCount > 0) 
            _avoidanceVector /= _avoidObjectsCount;

        return _avoidanceVector;
    }
}
