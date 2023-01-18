using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using Extensions;
using VContainer.Unity;

namespace UI
{
    public class BackButtonController : DisposableCancellable, IInitializable
    {
        private readonly BackButtonView _backButtonView;
        private readonly SceneLoader _sceneLoader;

        public BackButtonController(BackButtonView backButtonView, SceneLoader sceneLoader)
        {
            _backButtonView = backButtonView;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _backButtonView.BackButton.OnClickAsAsyncEnumerable(CancellationToken)
                .SubscribeAwait(LoadMenuSceneAsync, CancellationToken);
        }

        private async UniTask LoadMenuSceneAsync(CancellationToken cancellationToken)
        {
            await _sceneLoader.LoadMenuSceneAsync();
        }
    }
}