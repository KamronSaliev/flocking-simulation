using System;
using Configs.Behaviors;
using Enums;
using UnityEngine;

namespace Core
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