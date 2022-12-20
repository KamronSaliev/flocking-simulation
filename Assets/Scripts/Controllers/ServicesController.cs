using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Controllers
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