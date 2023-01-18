using UnityEngine;

namespace FlockingSimulation.Core
{
    public class CameraHolder
    {
        public Camera Camera { get; }

        public CameraHolder(Camera camera)
        {
            Camera = camera;
        }
    }
}