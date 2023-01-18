using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Controllers
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