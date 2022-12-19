using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    private int _flockIndex;
    public int FlockIndex { get => _flockIndex; }

    private Collider2D _agentCollider;
    public Collider2D AgentCollider { get => _agentCollider; }

    private void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }
    
    public void Move(Vector2 velocity)
    {
        RotateTowardsDirection(velocity);
        MoveTowardsDirection(velocity);
    }

    public void BelongsToFlock(int flockIndex)
    {
        _flockIndex = flockIndex;
    }

    private void RotateTowardsDirection(Vector2 direction)
    {
        transform.up = direction;
    }
    
    private void MoveTowardsDirection(Vector2 direction)
    {
        transform.position += (Vector3) direction * Time.deltaTime;
    }
}
