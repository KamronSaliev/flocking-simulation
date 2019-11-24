using System.Collections.Generic;
using UnityEngine;

public abstract class FilteredFlockBehavior : FlockBehaviour
{
    /// <summary>
    /// The context filters
    /// </summary>
    public ContextFilter[] filters;
}
