using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FlockingSimulation.Attributes
{
    public class SerializableScene : PropertyAttribute
    {
        public string[] ScenePaths { get; }
        
        public string[] SceneNames { get; }
        
        
        public SerializableScene()
        {
            
#if UNITY_EDITOR
            
            var scenesGUIDs = AssetDatabase.FindAssets("t:Scene");
            ScenePaths = scenesGUIDs.Select(AssetDatabase.GUIDToAssetPath).ToArray();
            SceneNames = Array.ConvertAll(ScenePaths, Path.GetFileNameWithoutExtension);

#endif

        }
    }
}