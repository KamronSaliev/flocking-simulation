using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Flock Filter")]
public class FlockFilter : ContextFilter
{
    public override List<Transform> GetFilteredContext(FlockAgent agent, List<Transform> context)
    {
        filteredContext = new List<Transform>();
        
        for (int i = 0; i < context.Count; i++)
        {
            FlockAgent neighborAgent = context[i].GetComponent<FlockAgent>();

            // if the agent and neighbor are from the same flock...
            if (neighborAgent != null && agent.Flock == neighborAgent.Flock)
                filteredContext.Add(context[i]);
        }

        return filteredContext;
    }
}
