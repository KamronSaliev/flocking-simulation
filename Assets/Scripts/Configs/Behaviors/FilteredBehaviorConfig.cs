using FlockingSimulation.Configs.Filters;
using UnityEngine;

namespace FlockingSimulation.Configs.Behaviors
{
    public abstract class FilteredBehaviorConfig : BehaviorConfig
    {
        /// <summary>
        ///     The context filters
        /// </summary>
        [SerializeField] protected ContextFilter[] _filters;
    }
}