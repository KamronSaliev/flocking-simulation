using FlockingSimulation.Controllers;
using FlockingSimulation.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FlockingSimulation.LifetimeScopes
{
    public class MenuLifetimeScope : LifetimeScope
    {
        [SerializeField] private MenuView _menuView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_menuView);

            builder.RegisterEntryPoint<MenuController>();
        }
    }
}