using System;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Core
{
    public class SceneLoader
    {
        public event Action SceneLoaded = delegate { };
        public event Action SceneStartLoading = delegate { };

        public int ActiveSceneIndex { get; private set; }

        private readonly ScenesConfig _scenesConfig;

        public SceneLoader(ScenesConfig scenesConfig)
        {
            _scenesConfig = scenesConfig;
        }

        public async UniTask LoadMenuSceneAsync()
        {
            await LoadSceneAsync(_scenesConfig.MenuSceneIndex);
        }

        public async UniTask LoadSimulationSceneAsync()
        {
            await LoadSceneAsync(_scenesConfig.SimulationSceneIndex);
        }

        public async UniTask LoadLastSceneAsync()
        {
            await LoadSceneAsync(ActiveSceneIndex);
        }

        private async UniTask LoadSceneAsync(int index)
        {
            await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            

            var sceneLoadingOperation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            SceneStartLoading.Invoke();

            await UniTask.WaitUntil(() => sceneLoadingOperation.isDone);

            var scene = SceneManager.GetSceneByBuildIndex(index);

            SceneManager.SetActiveScene(scene);
            ActiveSceneIndex = index;

            SceneLoaded.Invoke();

            foreach (var rootGameObject in scene.GetRootGameObjects())
            {
                if (!rootGameObject.TryGetComponent(out LifetimeScope scope))
                {
                    continue;
                }

                scope.Build();
                break;
            }
        }
    }
}