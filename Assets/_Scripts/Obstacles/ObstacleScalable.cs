using System;
using DG.Tweening;
using UnityEngine;

public class ObstacleScalable : Obstacle
{
    private void Awake()
    {
        _scaleCommand = new ScaleCommand(transform, (-1) * maxScale, scaleChangeSpeed);
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

        transform.DOPunchScale(Vector3.one * 0.25f, 1.0f)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
}