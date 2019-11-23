using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance Behavior")]
public class AvoidanceBehavior : FlockBehaviour
{
    private Vector2 _avoidanceVector;
    private int _avoidObjectsCount;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _avoidanceVector = Vector2.zero;
        _avoidObjectsCount = 0;
        
        if (context.Count == 0)
            return Vector2.zero;
            
        for (int i = 0; i < context.Count; i++)
        {
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
