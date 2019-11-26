using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
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
    private CircleCollider2D _agentCollider;
    public CircleCollider2D AgentCollider { get => _agentCollider; }

    void Start()
    {
        _agentCollider = GetComponent<CircleCollider2D>();
    }
    
    /// <summary>
    /// Moves the agent towards the velocity vector
    /// </summary>
    /// <param name="velocity">The vector of direction</param>
    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    /// <summary>
    /// Makes the flock agent related to its flock
    /// </summary>
    /// <param name="flockIndex">The flock to relate to</param>
    public void BelongsToFlock(int flockIndex)
    {
        _flockIndex = flockIndex;
    }
}
