using Configs;
using Core;
using Enums;

namespace Controllers
{
    public class BehaviorSelector
    {
        public Behavior CurrentBehavior { get; private set; }

        private readonly BehaviorTypesConfig _behaviorTypesConfig;

        public BehaviorSelector(BehaviorTypesConfig behaviorTypesConfig)
        {
            _behaviorTypesConfig = behaviorTypesConfig;
        }

        public void Select(BehaviorType behaviorType)
        {
            CurrentBehavior = _behaviorTypesConfig.GetBehaviorByType(behaviorType);
        }
    }
}