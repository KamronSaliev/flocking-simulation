using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Attraction To Point Behavior")]
public class AttractionToPointBehavior : FlockBehaviour
{
    /// <summary>
    /// The transforms of the points to which the agents are attracted
    /// </summary>
    [SerializeField]
    private Vector2[] points;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        if (points.Length == 0)
            return Vector2.zero;
            
        Vector2 pointTowardsVector = GetClosestPoint(currentAgent.transform) - (Vector2)currentAgent.transform.position;
        return pointTowardsVector;
    }

    /// <summary>
    /// Defines to which destination point the agent should move
    /// </summary>
    /// <param name="currentAgentTransform">The transform of the current agent</param>
    private Vector2 GetClosestPoint(Transform currentAgentTransform)
    {
        // initially the destination point is selected as the first point
        Vector2 closestPoint = points[0];
        float closestPointDistance = Vector2.Distance(currentAgentTransform.position, points[0]);

        for (int i = 1; i < points.Length; i++)
        {
            float distanceToPoint = Vector2.Distance(currentAgentTransform.position, points[i]);
            if (distanceToPoint < closestPointDistance)
            {
                closestPointDistance = distanceToPoint;
                closestPoint = points[i];
            }
        }
        
        return closestPoint;
    }
}
