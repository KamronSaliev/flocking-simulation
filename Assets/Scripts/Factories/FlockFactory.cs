using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;
using Views;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Factories
{
    public class FlockFactory : IDisposable
    {
        public List<FlockAgentView> Agents => _agents;

        private readonly FlockSettingsConfig _flockSettingsConfig;
        private readonly Transform _rootTransform;

        private readonly List<FlockAgentView> _agents = new List<FlockAgentView>();

        public FlockFactory(FlockSettingsConfig flockSettingsConfig, Transform rootTransform)
        {
            _flockSettingsConfig = flockSettingsConfig;
            _rootTransform = rootTransform;
        }

        public void CreateAgents()
        {
            for (int i = 0; i < _flockSettingsConfig.AgentCount; i++)
            {
                CreateAgent();
            }
        }
        
        public FlockAgentView CreateAgent()
        {
            return CreateAgent(GetRandomAgentType());
        }

        public FlockAgentView CreateAgent(int type)
        {
            var newAgent = Object.Instantiate(
                _flockSettingsConfig.AgentTypes[type],
                _flockSettingsConfig.FlockDensity * _flockSettingsConfig.AgentCount * Random.insideUnitCircle,
                Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f)),
                _rootTransform);

            _agents.Add(newAgent);

            var index = _agents.Count;
            newAgent.UpdateName(type, index);
            newAgent.BelongsToFlock(type);

            return newAgent;
        }

        public int GetRandomAgentType()
        {
            return Random.Range(0, _flockSettingsConfig.AgentTypes.Length);
        }

        public void Dispose()
        {
            for (var i = 0; i < _agents.Count; i++)
            {
                Object.Destroy(_agents[i]);
            }

            _agents.Clear();
        }
    }
}