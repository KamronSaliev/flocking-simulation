using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Configs.Filters
{
    [CreateAssetMenu(menuName = "Simulation/Filters/LayerFilter")]
    public class LayerFilter : ContextFilter
    {
        [SerializeField] private LayerMask _layerMask;

        public override List<Transform> GetFilteredContext(FlockAgentView agent, List<Transform> context)
        {
            var filteredContext = new List<Transform>();

            for (var i = 0; i < context.Count; i++)
            {
                if (context[i].gameObject.layer != _layerMask)
                {
                    filteredContext.Add(context[i]);
                }
            }

            return filteredContext;
        }
    }
}