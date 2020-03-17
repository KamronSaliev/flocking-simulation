using UnityEngine;

public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// The maximum scale of an obstacle that it can reach
    /// </summary>
    [Range(1.0f, 50.0f)]
    [SerializeField] private float maxScale = 1.0f;
    
    /// <summary>
    /// The scale change speed of an obstacle
    /// </summary>
    [Range(1.0f, 10.0f)]
    [SerializeField] protected float scaleChangeSpeed = 10.0f;
    
    /// <summary>
    /// The size of the selected obstacle
    /// </summary>
    protected Vector3 _currentObstacleScale;

    private Sound sound;

    private void Awake()
    {
        sound = GetComponent<Sound>();
    }

    private void Start()
    {
        ObstaclesController.OnFocusAction += FocusObstacle;
        ObstaclesController.OnDestroyAction += DestroyObstacle;
    }

    private void OnDestroy()
    {
        ObstaclesController.OnFocusAction -= FocusObstacle;
        ObstaclesController.OnDestroyAction -= DestroyObstacle;
    }

    protected virtual void FocusObstacle(GameObject obj)
    {
        if (gameObject != obj) return;
        
        _currentObstacleScale = transform.localScale;
        gameObject.transform.localScale = Vector3.Lerp(_currentObstacleScale, Vector3.one * maxScale, Time.deltaTime * scaleChangeSpeed);
    }
    
    protected virtual void DestroyObstacle(GameObject obj)
    {
        if (gameObject != obj) return;
        
        sound?.PlaySound();
        Destroy(gameObject);
    }
}
