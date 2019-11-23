using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite Behavior")]
public class CompositeBehavior : FlockBehaviour
{
    public CompositeBehaviorItem[] behaviors;
    
    private Vector2 _compositeVelocityVector;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _compositeVelocityVector = Vector2.zero;
        
        if (behaviors.Length == 0)
            return Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 movementVector = behaviors[i].flockbehavior.CalculateMove(currentAgent, context, flock);

            if (movementVector.magnitude > behaviors[i].weight)
                movementVector = movementVector.normalized * behaviors[i].weight;

            _compositeVelocityVector += movementVector;
        }

        return _compositeVelocityVector;
    }
}

[System.Serializable]
public class CompositeBehaviorItem
{
    public FlockBehaviour flockbehavior;
    public int weight;
}
