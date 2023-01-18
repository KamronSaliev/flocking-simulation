using System.Threading;
using Cysharp.Threading.Tasks;
using FlockingSimulation.Core;
using VContainer.Unity;

namespace FlockingSimulation.Controllers
{
    public class ServicesController : IAsyncStartable
    {
        private readonly SceneLoader _sceneLoader;

        public ServicesController(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _sceneLoader.LoadMenuSceneAsync();
        }
    }
}