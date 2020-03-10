using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    /// <summary>
    /// Flock that agent belongs to
    /// </summary>
    private int _flockIndex;
    public int FlockIndex { get => _flockIndex; }

    /// <summary>
    /// Collider of the agent
    /// </summary>
    private Collider2D _agentCollider;
    public Collider2D AgentCollider { get => _agentCollider; }

    private void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }
    
    /// <summary>
    /// Moves the agent towards the velocity vector
    /// </summary>
    /// <param name="velocity">The vector of direction</param>
    public void Move(Vector2 velocity)
    {
        RotateTowardsDirection(velocity);
        MoveTowardsDirection(velocity);
    }

    /// <summary>
    /// Makes the flock agent related to its flock
    /// </summary>
    /// <param name="flockIndex">The flock to relate to</param>
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
