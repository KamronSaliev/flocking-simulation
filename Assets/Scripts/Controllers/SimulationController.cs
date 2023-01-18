using Configs;
using Factories;
using VContainer.Unity;

namespace Controllers
{
    public class SimulationController : IInitializable, IStartable, ITickable
    {
        private readonly BehaviorSelector _behaviorSelector;
        private readonly FlockSettingsConfig _flockSettingsConfig;
        private readonly FlockFactory _flockFactory;

        private Behavior _behavior;

        public SimulationController(BehaviorSelector behaviorSelector, FlockSettingsConfig flockSettingsConfig,
            FlockFactory flockFactory)
        {
            _behaviorSelector = behaviorSelector;
            _flockSettingsConfig = flockSettingsConfig;
            _flockFactory = flockFactory;
        }

        public void Initialize()
        {
            _behavior = _behaviorSelector.CurrentBehavior;
        }
        
        public void Start()
        {
            _flockFactory.CreateAgents();
        }

        public void Tick()
        {
            foreach (var agent in _flockFactory.Agents)
            {
                var agentVelocity = _behavior.BehaviorConfig.CalculateMove(agent, _flockSettingsConfig);
                
                agentVelocity = agentVelocity.normalized * _flockSettingsConfig.AgentSpeed;

                agent.Move(agentVelocity);
            }
        }
    }
}