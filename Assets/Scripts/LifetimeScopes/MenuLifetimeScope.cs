using Controllers;
using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Views;

namespace LifetimeScopes
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