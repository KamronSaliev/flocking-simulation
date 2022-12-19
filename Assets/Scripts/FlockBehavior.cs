using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : ScriptableObject
{
    /// <summary>
    ///     Calculates the vector of movement for current agent
    /// </summary>
    /// <param name="currentAgent">The current flock agent</param>
    /// <param name="context">The list of transforms of neighbors</param>
    /// <param name="flock">The flock that agent belongs to</param>
    public abstract Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock);
}