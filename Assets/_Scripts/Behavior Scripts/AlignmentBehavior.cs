using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehaviour
{
    private Vector2 _alignmentVector;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return currentAgent.transform.up;
        
        for (int i = 0; i < context.Count; i++)
            _alignmentVector += (Vector2)context[i].up;

        _alignmentVector /= context.Count;

        return _alignmentVector;
    }
}
