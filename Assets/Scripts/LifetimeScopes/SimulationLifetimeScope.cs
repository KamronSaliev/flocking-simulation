using Configs;
using Controllers;
using Factories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LifetimeScopes
{
    public class SimulationLifetimeScope : LifetimeScope
    {
        [SerializeField] private FlockSettingsConfig _flockSettingsConfig;

        [SerializeField] private Transform _flockRoot;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_flockSettingsConfig);
            builder.RegisterInstance(_flockRoot);

            builder.Register<FlockFactory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterEntryPoint<SimulationController>();
        }
    }
}