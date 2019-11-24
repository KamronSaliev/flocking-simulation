using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Smoothed Alignment Behavior")]
public class SmoothedAlignmentBehavior : AlignmentBehavior
{
    /// <summary>
    /// The vector to align with vectors
    /// </summary>
    private Vector2 _smoothedAlignmentVector;
    
    // Properties for smooth alignment
    private Vector2 _currentVelocity;
    [SerializeField] private float smoothTime = 1f;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _smoothedAlignmentVector = base.CalculateMove(currentAgent, context, flock);
        
        // gradually changes the vector
        _smoothedAlignmentVector = Vector2.SmoothDamp(currentAgent.transform.up, _smoothedAlignmentVector, ref _currentVelocity, smoothTime);    
        
        return _smoothedAlignmentVector;
    }
}
