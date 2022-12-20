using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Views;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Factories
{
    public class FlockFactory : IDisposable
    {
        public List<FlockAgentView> Agents { get; } = new List<FlockAgentView>();

        private readonly FlockSettingsConfig _flockSettingsConfig;
        private readonly IObjectResolver _resolver;
        private readonly Transform _rootTransform;

        public FlockFactory(FlockSettingsConfig flockSettingsConfig, IObjectResolver resolver, Transform rootTransform)
        {
            _flockSettingsConfig = flockSettingsConfig;
            _resolver = resolver;
            _rootTransform = rootTransform;
        }

        public void CreateAgents()
        {
            for (var i = 0; i < _flockSettingsConfig.AgentCount; i++)
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
            var newAgent = _resolver.Instantiate(
                _flockSettingsConfig.AgentTypes[type],
                _flockSettingsConfig.FlockDensity * _flockSettingsConfig.AgentCount * Random.insideUnitCircle,
                Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f)),
                _rootTransform);

            Agents.Add(newAgent);

            var index = Agents.Count;
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
            for (var i = 0; i < Agents.Count; i++)
            {
                Object.Destroy(Agents[i]);
            }

            Agents.Clear();
        }
    }
}