using Configs;
using Controllers;
using Factories;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LifetimeScopes
{
    public class SimulationLifetimeScope : LifetimeScope
    {
        [SerializeField] private FlockSettingsConfig _flockSettingsConfig;

        [SerializeField] private Transform _flockRoot;

        [SerializeField] private BackButtonView _backButtonView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_flockSettingsConfig);
            builder.RegisterInstance(_flockRoot);

            builder.Register<FlockFactory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterEntryPoint<SimulationController>();
            
            RegisterUI(builder);
        }

        private void RegisterUI(IContainerBuilder builder)
        {
            builder.RegisterComponent(_backButtonView);
            
            builder.RegisterEntryPoint<BackButtonController>();
        }
    }
}