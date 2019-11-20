using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FlockAgent : MonoBehaviour
{
    private CircleCollider2D _agentCollider;

    private float _randomX;
    private float _randomY;

    public CircleCollider2D AgentCollider
    {
        get => _agentCollider;
    }

    void Start()
    {
        _agentCollider = GetComponent<CircleCollider2D>();
        _randomX = Random.Range(-1f, 1f);
        _randomY = Random.Range(-1f, 1f);
    }

    private void Update()
    {
        Vector2 velocityVector = new Vector2(_randomX, _randomY);
        Move(velocityVector);
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += new Vector3(velocity.x, velocity.y, 0f) * Time.deltaTime;
    }
}
