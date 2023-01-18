using UnityEngine;

namespace FlockingSimulation.Configs
{
    [CreateAssetMenu(menuName = "Simulation/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public int MenuSceneIndex => _menuSceneIndex;

        public int SimulationSceneIndex => _simulationSceneIndex;

        // TODO: Use scene serialization, update drawer logic
        [SerializeField] private int _menuSceneIndex = 1;

        [SerializeField] private int _simulationSceneIndex = 2;
    }
}