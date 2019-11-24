using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite Behavior")]
public class CompositeBehavior : FlockBehaviour
{
    /// <summary>
    /// Single core behaviors with their weights of impact on flock behavior
    /// </summary>
    [SerializeField] private CompositeBehaviorItem[] behaviors;
    
    /// <summary>
    /// The resulting vector of movement, calculated using the weights of each core behavior
    /// </summary>
    private Vector2 _compositeVelocityVector;
    
    /// <summary>
    /// The sum of weights of behaviors
    /// </summary>
    private float _weightsSum;

    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _compositeVelocityVector = Vector2.zero;
        _weightsSum = 0;
        
        if (behaviors.Length == 0)
            return Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
            _weightsSum += behaviors[i].weight;
        
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 movementVector = behaviors[i].flockBehavior.CalculateMove(currentAgent, context, flock);
            
            // every behavior vector is multiplied by the ratio of its weight to the sum all weights
            movementVector *= (behaviors[i].weight / _weightsSum);
            _compositeVelocityVector += movementVector;
        }

        return _compositeVelocityVector;
    }
}

[System.Serializable]
public class CompositeBehaviorItem
{
    public FlockBehaviour flockBehavior;
    public float weight;
}
