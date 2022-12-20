using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Configs.Filters
{
    [CreateAssetMenu(menuName = "Simulation/Filters/FlockFilter")]
    public class FlockFilter : ContextFilter
    {
        public override List<Transform> GetFilteredContext(FlockAgentView agent, List<Transform> context)
        {
            var filteredContext = new List<Transform>();

            for (var i = 0; i < context.Count; i++)
            {
                var neighborAgent = context[i].GetComponent<FlockAgentView>();

                // if the agent and neighbor are from the same flock...
                if (neighborAgent != null && agent.FlockIndex == neighborAgent.FlockIndex)
                {
                    filteredContext.Add(context[i]);
                }
            }

            return filteredContext;
        }
    }
}