using UnityEngine;
using UnityEngine.Events;

public class ObstaclesController : MonoBehaviour
{
    /// <summary>
    /// The boolean chechbox to control generation of obstacles
    /// </summary>
    [SerializeField] private bool canGenerateObstacles = true;
    
    /// <summary>
    /// The maximum number of the obstacles on the scene
    /// </summary>
    [Range(1, 20)]
    [SerializeField] private int obstaclesMaxCount = 10;
    
    /// <summary>
    /// The prefab of an obstacle to instantiate
    /// </summary>
    [SerializeField] private GameObject[] obstaclePrefabs;
    
    /// <summary>
    /// The layer of an obstacle
    /// </summary>
    [SerializeField] private LayerMask obstacleLayer;
     
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
    /// The obstacle counter
    /// </summary>
    private int _obstaclesCount;
    
    // Events and actions to call on create, focus, destroy
    public static UnityAction<GameObject> OnFocusAction, OnDestroyAction;
    
    private void Update()
    {
        if (!canGenerateObstacles) return;
            
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
            {
                CreateObstacle(_rayEndPoint); // if a ray is casted and no obstacle is found, then a new obstacle is created
            }
            else
            {
                _currentGameObject = _raycastHit.transform.gameObject;
                
                OnDestroyAction?.Invoke(_currentGameObject);
                _obstaclesCount--;
            }
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
            
            OnFocusAction?.Invoke(_currentGameObject);
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

        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        
        _currentGameObject = Instantiate(
            obstaclePrefabs[randomIndex], 
            position, 
            Quaternion.identity);
        
        _currentGameObject.transform.SetParent(gameObject.transform);
        _currentGameObject.name = Constants.ObstaclePrefix + _obstaclesCount;
        
        _obstaclesCount++;
    }
}
