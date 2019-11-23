using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        
        DontDestroyOnLoad(this);
    }

    public void SwitchScene(Object scene)
    {
        SceneManager.LoadScene(scene.name);
    }
}
