using Configs;
using Controllers;
using Core;
using Factories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LifetimeScopes
{
    public class DemoSimulationLifetimeScope : LifetimeScope
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private BehaviorTypesConfig _behaviorTypesConfig;

        [SerializeField] private FlockSettingsConfig _flockSettingsConfig;

        [SerializeField] private Transform _flockRoot;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_behaviorTypesConfig);
            builder.RegisterInstance(_flockSettingsConfig);
            builder.RegisterInstance(_flockRoot);

            builder.Register<CameraHolder>(Lifetime.Singleton).WithParameter(_camera);
            builder.Register<BehaviorSelector>(Lifetime.Singleton);
            builder.Register<FlockFactory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterEntryPoint<SimulationController>();
        }
    }
}