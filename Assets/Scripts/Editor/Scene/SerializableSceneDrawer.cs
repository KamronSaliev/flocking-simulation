using System;
using FlockingSimulation.Attributes;
using UnityEditor;
using UnityEngine;

namespace Editor.Scene
{
    [CustomPropertyDrawer(typeof(SerializableScene))]
    public class SerializableSceneDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!(attribute is SerializableScene serializableScene))
            {
                return;
            }

            var scenePaths = serializableScene.ScenePaths;
            var sceneNames = serializableScene.SceneNames;
            var displayList = new string[scenePaths.Length];
            
            for (var i = 0; i < scenePaths.Length; i++)
            {
                displayList[i] = scenePaths[i].Replace("Assets/", "");
            }

            var index = Mathf.Max(0, Array.IndexOf(scenePaths, property.stringValue));
            index = EditorGUI.Popup(position, property.displayName, index, displayList);
            
            property.stringValue = sceneNames[index];
        }
    }
}