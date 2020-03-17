using UnityEngine;

public class ObstacleDefault : Obstacle
{
    /// <summary>
    /// Sound to play
    /// </summary>
    private Sound sound;

    private void Awake()
    {
        sound = GetComponent<Sound>();
        
        _scaleCommand = new ScaleCommand(transform, maxScale, scaleChangeSpeed);
    }

    protected override void FocusObstacle(GameObject obj)
    {
        if (gameObject != obj) return;
        
        _scaleCommand.Execute();
        _executedCommands.Push(_scaleCommand);
    }
    
    protected override void DestroyObstacle(GameObject obj)
    {
        if (gameObject != obj) return;
        
        sound?.PlaySound();
        Destroy(gameObject);
    }
}
