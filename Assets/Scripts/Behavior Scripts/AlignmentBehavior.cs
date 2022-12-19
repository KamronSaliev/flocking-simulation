using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment Behavior")]
public class AlignmentBehavior : FilteredFlockBehavior
{
    /// <summary>
    ///     The vector to align with vectors
    /// </summary>
    private Vector2 _alignmentVector;

    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _alignmentVector = Vector2.zero;

        if (context.Count == 0)
        {
            return currentAgent.transform.up;
        }

        // Filtering the context
        for (var i = 0; i < filters.Length; i++)
        {
            if (filters[i] != null)
            {
                context = filters[i].GetFilteredContext(currentAgent, context);
            }
        }

        for (var i = 0; i < context.Count; i++)
        {
            _alignmentVector += (Vector2)context[i].up;
        }

        _alignmentVector /= context.Count;

        return _alignmentVector;
    }
}