using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using Enums;
using Extensions;
using UnityEngine;
using VContainer.Unity;
using Views;

namespace Controllers
{
    public class MenuController : DisposableCancellable, IInitializable
    {
        private readonly MenuView _menuView;
        private readonly SceneLoader _sceneLoader;
        private readonly BehaviorSelector behaviorSelector;

        public MenuController(MenuView menuView, SceneLoader sceneLoader, BehaviorSelector behaviorSelector)
        {
            _menuView = menuView;
            _sceneLoader = sceneLoader;
            this.behaviorSelector = behaviorSelector;
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
            Debug.Log($"[{nameof(MenuController)}] LoadAlignment");

            await LoadByBehavior(BehaviorType.Alignment);
        }

        private async UniTask LoadAttractionSimulationSceneAsync(CancellationToken cancellationToken)
        {
            Debug.Log($"[{nameof(MenuController)}] LoadAttraction");

            await LoadByBehavior(BehaviorType.Attraction);
        }

        private async UniTask LoadAvoidanceSimulationSceneAsync(CancellationToken cancellationToken)
        {
            Debug.Log($"[{nameof(MenuController)}] LoadAvoidance");

            await LoadByBehavior(BehaviorType.Avoidance);
        }

        private async UniTask LoadCohesionSimulationSceneAsync(CancellationToken cancellationToken)
        {
            Debug.Log($"[{nameof(MenuController)}] LoadCohesion");

            await LoadByBehavior(BehaviorType.Cohesion);
        }

        private async UniTask LoadCompositeSimulationSceneAsync(CancellationToken cancellationToken)
        {
            Debug.Log($"[{nameof(MenuController)}] LoadComposite");

            await LoadByBehavior(BehaviorType.Composite);
        }

        private async UniTask LoadByBehavior(BehaviorType behaviorType)
        {
            behaviorSelector.Select(behaviorType);

            await _sceneLoader.LoadSimulationSceneAsync();
        }
    }
}