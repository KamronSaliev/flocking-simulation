using FlockingSimulation.Controllers;
using VContainer;
using VContainer.Unity;

namespace FlockingSimulation.LifetimeScopes
{
    public class LauncherLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Launcher>();
        }
    }
}