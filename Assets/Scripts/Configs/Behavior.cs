using System;
using FlockingSimulation.Configs.Behaviors;
using FlockingSimulation.Enums;
using UnityEngine;

namespace FlockingSimulation.Configs
{
    [Serializable]
    public class Behavior
    {
        public BehaviorType BehaviorType => _behaviorType;

        public BehaviorConfig BehaviorConfig => _behaviorConfig;

        [SerializeField] private BehaviorType _behaviorType;
    
        [SerializeField] private BehaviorConfig _behaviorConfig;
    }
}