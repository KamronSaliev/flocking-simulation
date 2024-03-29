﻿using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Configs.Filters
{
    public abstract class ContextFilter : ScriptableObject
    {
        /// <summary>
        ///     Filters the context (neighbors of the selected flock agent)
        /// </summary>
        /// <param name="agent">The selected flock agent</param>
        /// <param name="context">The original context</param>
        public abstract List<Transform> GetFilteredContext(FlockAgentView agent, List<Transform> context);
    }
}