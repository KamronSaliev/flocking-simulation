using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Smoothed Cohesion Behavior")]
public class SmoothedCohesionBehavior : CohesionBehavior
{
    /// <summary>
    ///     The vector to stay near the detected neighbors
    /// </summary>
    private Vector2 _smoothedCohesionVector;

    // Properties for smooth alignment
    private Vector2 _currentVelocity;
    [SerializeField] private float smoothTime = 1f;

    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        _smoothedCohesionVector = base.CalculateMove(currentAgent, context, flock);

        // gradually changes the vector
        _smoothedCohesionVector = Vector2.SmoothDamp(currentAgent.transform.up, _smoothedCohesionVector,
            ref _currentVelocity, smoothTime);

        return _smoothedCohesionVector;
    }
}