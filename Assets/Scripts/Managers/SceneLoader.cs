using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        ScenesManager.instance.SwitchScene(sceneName);
    }
}