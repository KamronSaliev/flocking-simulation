using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    /// <summary>
    /// The maximum scale of an obstacle that it can reach
    /// </summary>
    [Range(1.0f, 50.0f)]
    [SerializeField] protected float maxScale = 1.0f;
    
    /// <summary>
    /// The scale change speed of an obstacle
    /// </summary>
    [SerializeField] protected float scaleChangeSpeed = 10.0f;

    // Used for controlling commands
    protected ICommand _scaleCommand;
    protected readonly Stack<ICommand> _executedCommands = new Stack<ICommand>();
    
    private void Start()
    {
        ObstaclesController.Instance.OnFocusAction += FocusObstacle;
        ObstaclesController.Instance.OnDestroyAction += DestroyObstacle;
        ObstaclesController.Instance.OnRevertAction += Revert;
    }

    private void OnDestroy()
    {
        ObstaclesController.Instance.OnFocusAction -= FocusObstacle;
        ObstaclesController.Instance.OnDestroyAction -= DestroyObstacle;
        ObstaclesController.Instance.OnRevertAction -= Revert;
    }
    
    protected abstract void FocusObstacle(GameObject obj);

    protected abstract void DestroyObstacle(GameObject obj);

    private void Revert(GameObject obj)
    {
        if (gameObject != obj) return;
        
        if (_executedCommands.Count == 0) 
            return;
        
        _executedCommands.Pop().Revert();
    }
}
