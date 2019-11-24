using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    /// <summary>
    /// The maximum number of the obstacles on the scene
    /// </summary>
    [SerializeField] private int obstaclesMaxCount = 10;
    /// <summary>
    /// The prefab of an obstacle to instantiate
    /// </summary>
    [SerializeField] private GameObject obstaclePrefab;
    /// <summary>
    /// The layer of an obstacle
    /// </summary>
    [SerializeField] private LayerMask obstacleLayer;
    /// <summary>
    /// The maximum size of an obstacle that it can reach
    /// </summary>
    [SerializeField] private float obstacleMaxScale = 10.0f;
    /// <summary>
    /// The vector of ray
    /// </summary>
    private Vector3 _rayEndPoint;
    /// <summary>
    /// The object that is detected by ray
    /// </summary>
    private RaycastHit2D _raycastHit;
    /// <summary>
    /// The gameObject of the selected obstacle
    /// </summary>
    private GameObject _currentGameObject;
    /// <summary>
    /// The size of the selected obstacle
    /// </summary>
    private Vector3 _currentObstacleScale;
    /// <summary>
    /// The obstacle counter
    /// </summary>
    private int _obstaclesCount;
    
    private void Update()
    {
        HandleMousePressing();
        HandleMouseHolding();
        HandleMouseReleasing();
    }
    
    /// <summary>
    /// User pressed LeftMouseButton
    /// </summary>
    private void HandleMousePressing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rayEndPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _raycastHit = Physics2D.Raycast(_rayEndPoint, Vector2.zero, Mathf.Infinity, obstacleLayer);

            if (_raycastHit.transform == null)
                CreateObstacle(_rayEndPoint); // if a ray is casted and no obstacle is found, then a new obstacle is created
            else
                DestroySelectedObstacle(_raycastHit.transform.gameObject); // if a ray is casted on an obstacle, then the obstacle is destroyed
        }
    }
    
    /// <summary>
    /// User is holding LeftMouseButton
    /// </summary>
    private void HandleMouseHolding()
    {
        if (Input.GetMouseButton(0))
        {
            _rayEndPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _raycastHit = Physics2D.Raycast(_rayEndPoint, Vector2.zero, Mathf.Infinity, obstacleLayer);

            if (_raycastHit.transform == null)
                return;
            
            _currentGameObject = _raycastHit.transform.gameObject;
            _currentObstacleScale = _currentGameObject.transform.localScale;
            
            // while the user holds the button, a selected obstacle is enlarged
            EnlargeSelectedObstacle(_currentGameObject);
        }
    }
    
    /// <summary>
    /// User released LeftMouseButton
    /// </summary>
    private void HandleMouseReleasing()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _currentGameObject = null;
        }
    }

    private void CreateObstacle(Vector2 position)
    {
        if (_obstaclesCount > obstaclesMaxCount) return;

        _currentGameObject = Instantiate(obstaclePrefab, position, Quaternion.identity);
        _currentGameObject.transform.SetParent(gameObject.transform);
        _currentGameObject.name = Constants.ObstacleName + _obstaclesCount;
        
        _obstaclesCount++;
    }

    private void DestroySelectedObstacle(GameObject gameObject)
    {
        Destroy(gameObject);
        _obstaclesCount--;
    }
    
    private void EnlargeSelectedObstacle(GameObject gameObject)
    {
        gameObject.transform.localScale = Vector3.Lerp(_currentObstacleScale, Vector3.one * obstacleMaxScale, Time.deltaTime);
    }
}
