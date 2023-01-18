using FlockingSimulation.Configs;
using FlockingSimulation.Controllers;
using FlockingSimulation.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlockingSimulation.LifetimeScopes
{
    public class ServicesLifetimeScope : LifetimeScope
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private ScenesConfig _scenesConfig;

        [SerializeField] private BehaviorTypesConfig _behaviorTypesConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CameraHolder>(Lifetime.Singleton).WithParameter(_camera);

            builder.Register<SceneLoader>(Lifetime.Singleton).WithParameter(_scenesConfig);
            builder.Register<BehaviorSelector>(Lifetime.Singleton).WithParameter(_behaviorTypesConfig);

            builder.RegisterEntryPoint<ServicesController>();
        }
    }
}