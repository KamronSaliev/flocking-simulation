using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using Enums;
using Extensions;
using VContainer.Unity;
using Views;

namespace Controllers
{
    public class MenuController : DisposableCancellable, IInitializable
    {
        private readonly MenuView _menuView;
        private readonly SceneLoader _sceneLoader;
        private readonly BehaviorSelector _behaviorSelector;

        public MenuController(MenuView menuView, SceneLoader sceneLoader, BehaviorSelector behaviorSelector)
        {
            _menuView = menuView;
            _sceneLoader = sceneLoader;
            _behaviorSelector = behaviorSelector;
        }

        public void Initialize()
        {
            _menuView.AlignmentBehaviorButton.OnClickAsAsyncEnumerable(CancellationToken)
                .SubscribeAwait(LoadAlignmentSimulationSceneAsync, CancellationToken);

            _menuView.AttractionBehaviorButton.OnClickAsAsyncEnumerable(CancellationToken)
                .SubscribeAwait(LoadAttractionSimulationSceneAsync, CancellationToken);

            _menuView.AvoidanceBehaviorButton.OnClickAsAsyncEnumerable(CancellationToken)
                .SubscribeAwait(LoadAvoidanceSimulationSceneAsync, CancellationToken);

            _menuView.CohesionBehaviorButton.OnClickAsAsyncEnumerable(CancellationToken)
                .SubscribeAwait(LoadCohesionSimulationSceneAsync, CancellationToken);

            _menuView.CompositeBehaviorButton.OnClickAsAsyncEnumerable(CancellationToken)
                .SubscribeAwait(LoadCompositeSimulationSceneAsync, CancellationToken);
        }

        private async UniTask LoadAlignmentSimulationSceneAsync(CancellationToken cancellationToken)
        {
            await LoadByBehavior(BehaviorType.Alignment);
        }

        private async UniTask LoadAttractionSimulationSceneAsync(CancellationToken cancellationToken)
        {
            await LoadByBehavior(BehaviorType.Attraction);
        }

        private async UniTask LoadAvoidanceSimulationSceneAsync(CancellationToken cancellationToken)
        {
            await LoadByBehavior(BehaviorType.Avoidance);
        }

        private async UniTask LoadCohesionSimulationSceneAsync(CancellationToken cancellationToken)
        {
            await LoadByBehavior(BehaviorType.Cohesion);
        }

        private async UniTask LoadCompositeSimulationSceneAsync(CancellationToken cancellationToken)
        {
            await LoadByBehavior(BehaviorType.Composite);
        }

        private async UniTask LoadByBehavior(BehaviorType behaviorType)
        {
            _behaviorSelector.Select(behaviorType);

            await _sceneLoader.LoadSimulationSceneAsync();
        }
    }
}