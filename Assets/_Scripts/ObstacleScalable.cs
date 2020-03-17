using DG.Tweening;
using UnityEngine;

public class ObstacleScalable : Obstacle
{
    protected override void DestroyObstacle(GameObject obj)
    {
        if (gameObject != obj) return;

        transform.DOPunchScale(Vector3.one, 1.0f)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
    
    protected override void FocusObstacle(GameObject obj)
    {
        if (gameObject != obj) return;
        
        _currentObstacleScale = transform.localScale;
        gameObject.transform.localScale = Vector3.Lerp(_currentObstacleScale, Vector3.zero, 0.01f);
    }
}
