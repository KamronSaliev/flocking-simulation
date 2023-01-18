using System.Threading;
using Cysharp.Threading.Tasks;
using FlockingSimulation.Core;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace FlockingSimulation.Controllers
{
    public class Launcher : IAsyncStartable
    {
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            var servicesSceneLoadTask = SceneManager.LoadSceneAsync(Constants.ServicesScene, LoadSceneMode.Additive)
                .ToUniTask(cancellationToken: cancellation);

            await servicesSceneLoadTask;
        }
    }
}