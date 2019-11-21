using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FlockAgent : MonoBehaviour
{
    private CircleCollider2D _agentCollider;

    public CircleCollider2D AgentCollider
    {
        get => _agentCollider;
    }

    void Start()
    {
        _agentCollider = GetComponent<CircleCollider2D>();
    }
    
    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
