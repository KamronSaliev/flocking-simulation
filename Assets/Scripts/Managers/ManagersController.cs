using UnityEngine;

public class ManagersController : MonoBehaviour
{
    public static ManagersController instance;

    [SerializeField] private GameObject globalManagerPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);

        CreateGlobalManager();
    }

    private void CreateGlobalManager()
    {
        Instantiate(globalManagerPrefab, transform);
    }
}