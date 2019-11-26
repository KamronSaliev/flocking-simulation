using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Layer Filter")]
public class LayerFilter : ContextFilter
{
    [SerializeField] private LayerMask layerMask;
    
    public override List<Transform> GetFilteredContext(FlockAgent agent, List<Transform> context)
    {
        List<Transform> filteredContext = new List<Transform>();
        
        for (int i = 0; i < context.Count; i++)
        {
            if (context[i].gameObject.layer != layerMask)
                filteredContext.Add(context[i]);
        }

        return filteredContext;
    }
}
