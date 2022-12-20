using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Simulation/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public int MenuSceneIndex => _menuSceneIndex;

        public int SimulationSceneIndex => _simulationSceneIndex;

        [SerializeField] private int _menuSceneIndex = 1;

        [SerializeField] private int _simulationSceneIndex = 2;
    }
}