using System.Collections.Generic;
using UnityEngine;

public abstract class FilteredFlockBehavior : FlockBehavior
{
    /// <summary>
    /// The context filters
    /// </summary>
    public ContextFilter[] filters;
}
