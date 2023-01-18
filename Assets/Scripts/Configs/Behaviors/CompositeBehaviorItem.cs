using System;
using UnityEngine;

namespace FlockingSimulation.Configs.Behaviors
{
    [Serializable]
    public class CompositeBehaviorItem
    {
        public BehaviorConfig BehaviorConfig => _behaviorConfig;

        public float Weight => _weight;

        [SerializeField] private BehaviorConfig _behaviorConfig;

        [SerializeField] private float _weight;
    }
}