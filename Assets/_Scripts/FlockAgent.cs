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
        transform.position += new Vector3(velocity.x, velocity.y, 0f) * Time.deltaTime;
    }
}
