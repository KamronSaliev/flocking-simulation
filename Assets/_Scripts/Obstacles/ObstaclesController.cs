using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ObstaclesController : MonoBehaviour
{
    public static ObstaclesController Instance;
    
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
    [SerializeField] private Obstacle[] obstacles;
    
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
    public UnityAction<GameObject> OnFocusAction, OnDestroyAction, OnRevertAction;
    // public UnityAction OnRevertAction;

    private Camera _cameraMain;
    private Camera cameraMain
    {
        get
        {
            if (_cameraMain == null)
                _cameraMain = Camera.main;

            return _cameraMain;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!canGenerateObstacles) return;
            
        HandleMousePressing();
        HandleMouseHolding();
        HandleMouseReleasing();
    }
    
    /// <summary>
    /// User pressed mouse button
    /// </summary>
    private void HandleMousePressing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rayEndPoint = cameraMain.ScreenToWorldPoint(Input.mousePosition);
            _raycastHit = Physics2D.Raycast(_rayEndPoint, Vector2.zero, Mathf.Infinity, obstacleLayer);
            
            if (_raycastHit.transform == null)
            {
                CreateObstacle(_rayEndPoint); // if a ray is casted and no obstacle is found, then a new obstacle is created
            }
            // else
            // {
            //     _currentGameObject = _raycastHit.transform.gameObject;
            //     
            //     OnDestroyAction?.Invoke(_currentGameObject);
            //     _obstaclesCount--;
            // }
        }
    }
    
    /// <summary>
    /// User is holding mouse button
    /// </summary>
    private void HandleMouseHolding()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            _rayEndPoint = cameraMain.ScreenToWorldPoint(Input.mousePosition);
            _raycastHit = Physics2D.Raycast(_rayEndPoint, Vector2.zero, Mathf.Infinity, obstacleLayer);

            if (_raycastHit.transform == null)
                return;
            
            _currentGameObject = _raycastHit.transform.gameObject;
            
            OnFocusAction?.Invoke(_currentGameObject);
        }
        
        if (Input.GetMouseButton(1))
        {
            _rayEndPoint = cameraMain.ScreenToWorldPoint(Input.mousePosition);
            _raycastHit = Physics2D.Raycast(_rayEndPoint, Vector2.zero, Mathf.Infinity, obstacleLayer);
            
            if (_raycastHit.transform == null)
                return;
            
            _currentGameObject = _raycastHit.transform.gameObject;
            
            OnRevertAction?.Invoke(_currentGameObject);
        }
    }
    
    /// <summary>
    /// User released mouse button
    /// </summary>
    private void HandleMouseReleasing()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _currentGameObject = null;
        }
    }

    /// <summary>
    /// Creates obstacle at some position
    /// </summary>
    /// <param name="position"></param>
    private void CreateObstacle(Vector2 position)
    {
        if (_obstaclesCount > obstaclesMaxCount) return;

        int randomIndex = Random.Range(0, obstacles.Length);
        
        _currentGameObject = Instantiate(
            obstacles[randomIndex].gameObject, 
            position, 
            Quaternion.identity);
        
        _currentGameObject.transform.SetParent(gameObject.transform);
        _currentGameObject.name = Constants.ObstaclePrefix + _obstaclesCount;
        
        _obstaclesCount++;
        
        DestroyObstacleOnTimer(_currentGameObject);
    }

    /// <summary>
    /// Destroys obstacle after some period of time
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="duration"></param>
    private void DestroyObstacleOnTimer(GameObject obj, float duration = 10.0f)
    {
        DOVirtual.DelayedCall(duration, () =>
        {
            OnDestroyAction?.Invoke(obj);
            _obstaclesCount--;
        });
    }
}
