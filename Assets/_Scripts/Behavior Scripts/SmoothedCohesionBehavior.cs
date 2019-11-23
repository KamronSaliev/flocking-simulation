using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Smoothed Cohesion Behavior")]
public class SmoothedCohesionBehavior : CohesionBehavior
{
    private Vector2 _smoothedCohesionVector;
    private Vector2 _currentVelocity;
    public float smoothTime = 1f;
    
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _smoothedCohesionVector = base.CalculateMove(currentAgent, context, flock);
        _smoothedCohesionVector = Vector2.SmoothDamp(currentAgent.transform.up, _smoothedCohesionVector, ref _currentVelocity, smoothTime);    
        
        return _smoothedCohesionVector;
    }
}
