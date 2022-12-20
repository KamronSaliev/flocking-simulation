using Configs;
using Core;
using Factories;
using UnityEngine;
using VContainer.Unity;

namespace Controllers
{
    public class SimulationController : IStartable, ITickable
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

        public void Start()
        {
            _behavior = _behaviorSelector.CurrentBehavior;
            
            Debug.Log($"{nameof(SimulationController)} Behavior: {_behavior.BehaviorType.ToString()}");

            _flockFactory.CreateAgents();
        }

        public void Tick()
        {
            foreach (var agent in _flockFactory.Agents)
            {
                var agentVelocity =
                    _behavior.BehaviorConfig.CalculateMove(agent, agent.GetNeighborObjects(), 
                        _flockSettingsConfig);
                
                agentVelocity = agentVelocity.normalized * _flockSettingsConfig.AgentSpeed;

                agent.Move(agentVelocity);
            }
        }
    }
}