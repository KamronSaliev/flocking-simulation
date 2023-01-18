using System.Linq;
using FlockingSimulation.Enums;
using UnityEngine;

namespace FlockingSimulation.Configs
{
    [CreateAssetMenu(menuName = "Simulation/BehaviorTypesConfig")]
    public class BehaviorTypesConfig : ScriptableObject
    {
        [SerializeField] private Behavior[] _behaviors;

        public Behavior GetBehaviorByType(BehaviorType behaviorType)
        {
            var behavior = _behaviors.FirstOrDefault();
            
            for (int i = 0; i < _behaviors.Length; i++)
            {
                if (_behaviors[i].BehaviorType == behaviorType)
                {
                    behavior = _behaviors[i];
                }
            }

            return behavior;
        }
    }
}