using Controllers;
using VContainer;
using VContainer.Unity;

namespace LifetimeScopes
{
    public class LauncherLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Launcher>();
        }
    }
}